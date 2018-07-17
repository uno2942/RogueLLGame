using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/** \brief The Manager class to controll whole gameboard.
 * \details This is an code for boardmanager, which is gameobject, and control the poition of player, camera in unity, and the door.
 */
public class BoardManager : MonoBehaviour {

    public const int verticalMovement = 10; /**< The vertical length of a board in the game. */
    public const int horizontalMovement = 18;/**< The vertical length of a board in the game. */


    public enum Direction { Right=0, UpSide=1, Left=2, DownSide=3};  /**< \brief 플레이어가 움직이는 방향에 대한 열거형 
                                                                          \details 문마다 이 열거형 변수를 가지고 있으며
                                                                                   문이 클릭되었을 때, 이 변수 방향으로
                                                                                    플레이어를 이동시킨다.
                                                                          \see Door*/
    public enum RoomType { Empty, NormalRoom, Hall, BossRoom, DrugRoom, RestRoom, LockedRoom, End, EndOfEnum}; /**< \brief 방의 종류에 대한 열거형 
                                                                                                                    \details 맵 파일을 파싱해서 읽은 데이터는
                                                                                                                    이 파일에서 처리해 맵을 만들며, 이 때 방의
                                                                                                                    종류에 따라 방에 놓여지는 게임 오브젝트가 다르기
                                                                                                                    때문에 이 방의 종류를 저장하기 위한 열거형이다.
                                                                                                                    */
    public enum NPCType { Empty, DrugExpert, InjectorCollector, DrugVecder, Psychiatrist, EmergencyBox, EndOfEnum };/**< \brief NPC의 종류에 대한 열거형 
                                                                                                                    \details NPC의 종류에 대한 열거형으로
                                                                                                                    이를 기반으로 NPC 게임 오브젝트를 게임에
                                                                                                                    뿌린다.
                                                                                                                    */
    public GameObject doorPrefab;
    public Camera gameCamera; /**< 플레이어가 이동할 때마다 플레이어를 비추는 카메라를 이동시켜야하기 때문에 필요한 카메라 변수 */
    public Player playerobejct;

    private List<MapTile> floor; /**< 한 층의 맵을 저장하기 위한 리스트 */ //get 한정으로 할지 고민
    private List<List<MapTile>> map; /**< 다수의 floor를 저장하기 위한 리스트 */
    private MapParser parser; /**< 맵 파서이다. */

    private int xPos; /**< 플레이어의 위치를 저장한다.(한 보드를 이동할 때마다 +-1을 한다.) */
    private int yPos; /**< 플레이어의 위치를 저장한다.(한 보드를 이동할 때마다 +-1을 한다.) */
    private int whichFloor;
    public Vector2 NowPos() 
    {
        return new Vector2 (xPos * horizontalMovement, yPos * verticalMovement);
    } /**< 실제 구현에서 플레이어 위치를 반환하는 함수이다. */

    /**
    * \brief 플레이어의 위치를 반환하는 속성이다.
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
     * \brief 사용자의 위치를 초기화한 후, 맵 파일을 파싱한 후 맵을 생성한다.
     * @todo We need make map parsing and door implementation and remove codes in this function. 
     */
    void Start() {

        GenerateDoor(0, 0); // 임시로 존재하는 코드.

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
     * 플레이어가 문을 클릭했을 때 문 프리팹이 이 함수를 콜한다. 이 함수는 플레이어와 카메라를 이동시킨다.
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

            DestroyDoor();
           

            switch( direction ) {
            case Direction.Right:
                GenerateDoor(14, 0);
                break;
            case Direction.Left:
                GenerateDoor( -14, 0 );
                break;
            case Direction.UpSide:
                GenerateDoor( 0, 10 );
                break;
            case Direction.DownSide:
                GenerateDoor( 0, -10 );
                break;
            }
        }
    }

    /**
     * NPC가 존재할 수 있는 맵 타일에 NPC를 생성한다.
     * @todo 해야한다.
     */
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
    /**
    * 적이 존재할 수 있는 맵 타일에 적을 생성한다.
    * @todo 해야한다.
    */
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
    /**
     * 아이템이 존재할 수 있는 맵에 아이템을 생성한다.
     * @todo 해야한다. 적이 존재하는 곳에 적이 드랍하는 아이템을 미리 뿌려놓을지 택해야 함.
     */
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

    /**
     * 문 (프리팹)을 생성한다.
     * @todo 지금은 사방에 문을 생성하게 하지만, 맵 타일이 붙어 있는 곳에만 생성하도록 해야한다.
     */
    void GenerateDoor(int x, int y) {

        GameObject doorObject = Instantiate( doorPrefab, new Vector2( GameObject.Find( "PlayerUI" ).transform.position.x + 7 + x, GameObject.Find( "PlayerUI" ).transform.position.y + 0+y ), Quaternion.identity ) as GameObject;
        Door door = doorObject.GetComponent<Door>();
        door.direction = Direction.Right;

        doorObject = Instantiate( doorPrefab, new Vector2( GameObject.Find( "PlayerUI" ).transform.position.x - 7 + x, GameObject.Find( "PlayerUI" ).transform.position.y + 0 + y ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.Left;

        doorObject = Instantiate( doorPrefab, new Vector2( GameObject.Find( "PlayerUI" ).transform.position.x + x, GameObject.Find( "PlayerUI" ).transform.position.y + 5 + y ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.UpSide;

        doorObject = Instantiate( doorPrefab, new Vector2( GameObject.Find( "PlayerUI" ).transform.position.x + x, GameObject.Find( "PlayerUI" ).transform.position.y - 5 + y ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.DownSide;
    }
    /**
     * 플레이어가 이동하면 문을 클릭해서 이동했을 때 원래 있던 문을 삭제하기 위한 함수
     */
    void DestroyDoor() {
        GameObject[] gObjects = GameObject.FindGameObjectsWithTag( "Door" );
        foreach (GameObject gObject in gObjects ) {
            Destroy( gObject );
        }
    }
}
