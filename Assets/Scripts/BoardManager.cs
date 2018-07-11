using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/** \brief The Manager class to controll whole gameboard.
 * \details This is an code for boardmanager, which is gameobject, and control the poition of player, camera in unity, and the door.
 */
public class BoardManager : MonoBehaviour {
    /** \brief This specifies how much the player moves when the player clicks a door.
     */
     //@{
    public const int verticalMovement = 10;
    public const int horizontalMovement = 18;
    //@}
    /** Direction enum variable setting direction of movement when the player clicked the door.
     */
    public enum Direction { Right=0, UpSide=1, Left=2, DownSide=3};
    public enum RoomType { Empty, NormalRoom, Hall, BossRoom, DrugRoom, RestRoom, LockedRoom, End, EndOfEnum};
    public enum NPCType { Empty, DrugExpert, InjectorCollector, DrugVecder, Psychiatrist, EmergencyBox, EndOfEnum };
    public GameObject doorPrefab;
    public Camera gameCamera;
    public Player playerobejct;
    private List<MapTile> floor; //get 한정으로 할지 고민
    private List<List<MapTile>> map;
    private MapParser parser;
    private int xPos, yPos;
    private int whichFloor;
    public Vector2 NowPos()
    {
        return new Vector2 (xPos * horizontalMovement, yPos * verticalMovement);
    }
    /**
 * The current position of the player.
 */
    //@{
    public int XPos
    {
        get
        {
            return xPos;
        }
    }

    public int YPos
    {
        get
        {
            return yPos;
        }
    }

    public int WhichFloor
    {
        get
        {
            return whichFloor;
        }
    }
    //@}
    /**
     * @todo We need make map parsing and door implementation and remove codes in this function. 
     */
    void Start() {

        GameObject doorObject = Instantiate( doorPrefab, new Vector2( 7, 0 ), Quaternion.identity ) as GameObject;
        Door door = doorObject.GetComponent<Door>();
        door.direction = Direction.Right;

        doorObject = Instantiate( doorPrefab, new Vector2( -7, 0 ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.Left;

        doorObject = Instantiate( doorPrefab, new Vector2( 0, 5 ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.UpSide;

        doorObject = Instantiate( doorPrefab, new Vector2( 0, -5 ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.DownSide;

        playerobejct = GameObject.Find( "Player" ).GetComponent<Player>();

        xPos = yPos = 0;
        whichFloor = 0;

        parser = new MapParser();
        floor = new List<MapTile>();
        map = new List<List<MapTile>>();
        parser.parse( ref map );




        Random.InitState( (int) System.DateTime.Now.Ticks );

        var IEmapTiles = from mapTile in floor
                         where mapTile.roomType == BoardManager.RoomType.NormalRoom
                         select mapTile;
        foreach( MapTile mapTile in IEmapTiles ) {

            int EnemyorNPCorItem = Random.Range( 0, 10 );
            if( EnemyorNPCorItem == 9 ) EnemyorNPCorItem -= 1;

            switch( EnemyorNPCorItem ) {
            case 0:
                GenerateNPCInMapTile( mapTile ); break;
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                GenerateEmepyInMapTile( mapTile ); break;
            case 7:
            case 8:
            case 9: GenerateItemInMapTile( mapTile ); break;
            }
        }

        IEmapTiles = from mapTile in floor
                     where mapTile.roomType == BoardManager.RoomType.LockedRoom
                     select mapTile;
        foreach( MapTile mapTile in IEmapTiles ) {

            int EnemyorNPCorItem = Random.Range( 0, 10 );
            if( EnemyorNPCorItem == 10 ) EnemyorNPCorItem -= 1;

            switch( EnemyorNPCorItem ) {
            case 0:
            case 1:
            case 2:
            case 3: GenerateNPCInMapTile( mapTile ); break;
            case 4:
            case 5:
                GenerateEmepyInMapTile( mapTile ); break;
            case 6:
            case 7:
            case 8:
            case 9:
                GenerateItemInMapTile( mapTile ); break;
            }
        }

        IEmapTiles = from mapTile in floor
                     where mapTile.roomType == BoardManager.RoomType.Hall
                     select mapTile;
        foreach( MapTile mapTile in IEmapTiles ) {

            int EnemyorNPCorItem = Random.Range( 0, 10 );
            if( EnemyorNPCorItem == 9 ) EnemyorNPCorItem -= 1;

            switch( EnemyorNPCorItem ) {
            case 0:
            case 1:
            case 2:
            case 3:
                GenerateEmepyInMapTile( mapTile ); break;
            case 4:
                GenerateItemInMapTile( mapTile ); break;
            }
        }

        IEmapTiles = from mapTile in floor
                     where mapTile.roomType == BoardManager.RoomType.DrugRoom
                     select mapTile;
        foreach( MapTile mapTile in IEmapTiles ) {
            GenerateItemInMapTile( mapTile );
        }

        IEmapTiles = from mapTile in floor
                     where mapTile.roomType == BoardManager.RoomType.RestRoom
                     select mapTile;
        foreach( MapTile mapTile in IEmapTiles ) {
            GenerateNPCInMapTile( mapTile );
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /**
     * When player clicked the door, door call this function with the direction the door having. It moves the player and the camera.
     */
    public void MoveNextRoom(Direction direction) {
        //if(map is valid)
        {
            switch(direction) {
            case Direction.Right:
                gameCamera.transform.position += new Vector3Int( horizontalMovement, 0, 0 );
                playerobejct.transform.position += new Vector3Int( horizontalMovement, 0, 0 );
                xPos++;
                break;
            case Direction.Left:
                gameCamera.transform.position -= new Vector3Int( horizontalMovement, 0, 0 );
                playerobejct.transform.position -= new Vector3Int( horizontalMovement, 0, 0 );
                xPos--;
                break;
            case Direction.UpSide:
                gameCamera.transform.position += new Vector3Int( 0, verticalMovement, 0 );
                playerobejct.transform.position += new Vector3Int( 0, verticalMovement, 0 );
                yPos++;
                break;
             case Direction.DownSide:
                gameCamera.transform.position -= new Vector3Int(0, verticalMovement, 0 );
                playerobejct.transform.position -= new Vector3Int( 0, verticalMovement, 0 );
                yPos--;
                break;
            }

        }
    }

    private void GenerateNPCInMapTile(MapTile mapTile) {
        int index=0;
        switch( mapTile.roomType ) {
        case RoomType.LockedRoom:
        case RoomType.NormalRoom: {
                do {
                    index = (int) Random.Range( 1, (int) NPCType.EndOfEnum );
                    if( index == (int) NPCType.EndOfEnum )
                        index = (int) NPCType.EndOfEnum - 1;
                } while( index == (int) NPCType.DrugVecder );
                mapTile.NPCList.Add( (NPCType) index ); break;
            }
        case RoomType.RestRoom: 
            {
                do {
                    index = (int) Random.Range( 1, (int) NPCType.EndOfEnum );
                    if( index == (int) NPCType.EndOfEnum )
                        index = (int) NPCType.EndOfEnum - 1;
                } while( index == (int) NPCType.DrugVecder );
                mapTile.NPCList.Add( (NPCType) index );
            }
            {
                do {
                    index = (int) Random.Range( 1, (int) NPCType.EndOfEnum );
                    if( index == (int) NPCType.EndOfEnum )
                        index = (int) NPCType.EndOfEnum - 1;
                } while( index == (int) NPCType.DrugVecder );
                mapTile.NPCList.Add( (NPCType) index );
            }
            mapTile.NPCList.Add( NPCType.DrugVecder );
            break;
        }
    }
    private void GenerateEmepyInMapTile( MapTile mapTile ) {
        /*
        int index = 0;
        switch( mapTile.roomType ) {
        case Enemy.LockedRoom:
        case RoomType.NormalRoom: {
                do {
                    index = (int) Random.Range( 1, (int) NPCType.EndOfEnum );
                    if( index == (int) NPCType.EndOfEnum )
                        index = (int) NPCType.EndOfEnum - 1;
                } while( index == (int) NPCType.DrugVecder );
                mapTile.NPCList.Add( (NPCType) index ); break;
            }
        case RoomType.RestRoom: {
                do {
                    index = (int) Random.Range( 1, (int) NPCType.EndOfEnum );
                    if( index == (int) NPCType.EndOfEnum )
                        index = (int) NPCType.EndOfEnum - 1;
                } while( index == (int) NPCType.DrugVecder );
                mapTile.NPCList.Add( (NPCType) index );
            } {
                do {
                    index = (int) Random.Range( 1, (int) NPCType.EndOfEnum );
                    if( index == (int) NPCType.EndOfEnum )
                        index = (int) NPCType.EndOfEnum - 1;
                } while( index == (int) NPCType.DrugVecder );
                mapTile.NPCList.Add( (NPCType) index );
            }
            mapTile.NPCList.Add( NPCType.DrugVecder );
            break;
        }
        */
    }
    
    private void GenerateItemInMapTile( MapTile mapTile ) {
/*
        int index = (int) Random.Range( 1, (int) ItemManager.ItemCategory.EndOfEnum);
        if( index == (int) ItemManager.ItemCategory.EndOfEnum )
            index = (int) ItemManager.ItemCategory.EndOfEnum - 1;
        mapTile.itemList.Add(( ItemManager.ItemCategory) index);
*/
    }


    public static int RandomGenerator(float[] percent) {
        if( percent.Sum() != 1f )
            return -1;
        else {
            float temp = Random.Range( 0, 1 );
            float[] interval = new float[percent.Length+1];
            interval[ 0 ] = 0f;
            for( int i = 0; i < percent.Length; i++ ) {
                interval[ i + 1 ] = interval[ i ] + percent[ i ];
                if( interval[ i ] <= temp && temp <= interval[ i + 1 ] )
                    return i;
                    }
            return -1;
        }
    }
}
