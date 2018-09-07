using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

/** \brief The Manager class to controll whole gameboard.
 * \details This is an code for boardmanager, which is gameobject, and control the poition of player, camera in unity, and the door.
 */
public class BoardManager : MonoBehaviour {

    public static int verticalMovement = 10; /**< The vertical length of a board in the game. */
    public static float horizontalMovement = 17.7792f;/**< The horizontal length of a board in the game. */


    public enum Direction { Right = 0, UpSide = 1, Left = 2, DownSide = 3 };  /**< \brief 플레이어가 움직이는 방향에 대한 열거형 
                                                                          \details 문마다 이 열거형 변수를 가지고 있으며
                                                                                   문이 클릭되었을 때, 이 변수 방향으로
                                                                                    플레이어를 이동시킨다.
                                                                          \see Door*/
    public enum RoomType { Empty, NormalRoom, Hall, BossRoom, DrugRoom, RestRoom, LockedRoom, PlayerStart, Equipment, End }; /**< \brief 방의 종류에 대한 열거형 
                                                                                                                    \details 맵 파일을 파싱해서 읽은 데이터는
                                                                                                                    이 파일에서 처리해 맵을 만들며, 이 때 방의
                                                                                                                    종류에 따라 방에 놓여지는 게임 오브젝트가 다르기
                                                                                                                    때문에 이 방의 종류를 저장하기 위한 열거형이다.
                                                                                                                    */
    public enum NPCType { Empty, MedicineMaster, InjectorCollector, CapsuleDespenser, MentalDoctor, MedicalBox };/**< \brief NPC의 종류에 대한 열거형 
                                                                                                                    \details NPC의 종류에 대한 열거형으로
                                                                                                                    이를 기반으로 NPC 게임 오브젝트를 게임에
                                                                                                                    뿌린다.
                                                                                                                    */
    public enum EnemyType { Empty, Dog, Rat, Human, AngryDog, BoundedCrazy, Gunner, HospitalDirector, Nurse, GPOSClub };

    public GameObject doorPrefab;
    public Camera gameCamera; /**< 플레이어가 이동할 때마다 플레이어를 비추는 카메라를 이동시켜야하기 때문에 필요한 카메라 변수 */
    public Camera minimapCamera;
    public Player playerobejct;
    public GameManager gameManager;

    private List<MapTile> floor; /**< 한 층의 맵을 저장하기 위한 리스트 */ //get 한정으로 할지 고민
    public Dictionary<MapGenerator.Coord, MapTile> CurrentMapOfFloor;
    private Dictionary<int, List<MapTile>> map; /**< 다수의 floor를 저장하기 위한 리스트 */
    private MapGenerator parser; /**< 맵 파서이다. */
    private MapTile currenttile; /**< 플레이어가 현재 있는 맵 타일 */

    public MapTile CurrentTile
    {
        get
        {
            return currenttile;
        }
    }

    private int xPos; /**< 플레이어의 위치를 저장한다.(한 보드를 이동할 때마다 +-1을 한다.) */
    private int yPos; /**< 플레이어의 위치를 저장한다.(한 보드를 이동할 때마다 +-1을 한다.) */
    private int whichFloor;

    private bool mapGened;

    public Vector2 NowPos() {
        return new Vector2( xPos * horizontalMovement, yPos * verticalMovement );
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
        
        playerobejct = GameObject.Find( "Player" ).GetComponent<Player>();

        xPos = yPos = 0;
        whichFloor = 0;

        parser = new MapGenerator();
        floor = new List<MapTile>();
        map = new Dictionary<int, List<MapTile>>();
        parser.parse( ref map );

        CurrentMapOfFloor = new Dictionary<MapGenerator.Coord, MapTile> ();
        parser.GenMapObject( map[ 0 ], ref CurrentMapOfFloor );
        mapGened = true;
        floor = map [0];

        //시작할 때, 플레이어 초기 위치에 있는 문들을 enable 시킴.
        currenttile =
            (from tile in floor
            where tile.x == 0 && tile.y == 0
            select tile).First<MapTile>();

        var curtransform = currenttile.gObject.transform;
        for ( var i = 0; i < curtransform.childCount; i++ )
        {
            curtransform.GetChild (i).gameObject.SetActive (true);
        }

        /*
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
                */
    }

    // Update is called once per frame
    void Update() {
        
    }
    /**
     * 플레이어가 문을 클릭했을 때 문 프리팹이 이 함수를 콜한다. 이 함수는 플레이어와 카메라를 이동시킨다.
     */
    public void MoveNextRoom( Direction direction ) {
        //if(map is valid)

        //맵을 이동할때 현재 있던 방의 문을 disable 시킴.
        var curtransform = currenttile.gObject.transform;
        for(var i = 0; i < curtransform.childCount; i++)
            curtransform.GetChild(i).gameObject.SetActive (false);

        {
            switch( direction ) {
            case Direction.Right:
                gameCamera.transform.position += new Vector3( horizontalMovement, 0, 0 );
                minimapCamera.transform.position += new Vector3( 0.5f, 0, 0 );
                playerobejct.transform.position += new Vector3( horizontalMovement, 0, 0 );
                xPos++;
                break;
            case Direction.Left:
                gameCamera.transform.position -= new Vector3( horizontalMovement, 0, 0 );
                minimapCamera.transform.position -= new Vector3( 0.5f, 0, 0 );
                playerobejct.transform.position -= new Vector3( horizontalMovement, 0, 0 );
                xPos--;
                break;
            case Direction.UpSide:
                gameCamera.transform.position += new Vector3Int( 0, verticalMovement, 0 );
                minimapCamera.transform.position += new Vector3( 0, 0.5f, 0 );
                playerobejct.transform.position += new Vector3Int( 0, verticalMovement, 0 );
                yPos++;
                break;
            case Direction.DownSide:
                gameCamera.transform.position -= new Vector3Int( 0, verticalMovement, 0 );
                minimapCamera.transform.position -= new Vector3( 0, 0.5f, 0 );
                playerobejct.transform.position -= new Vector3Int( 0, verticalMovement, 0 );
                yPos--;
                break;
            }
            
            currenttile =
                (from tile in floor
                 where tile.x == xPos && tile.y == yPos
                 select tile).First<MapTile> ();

            curtransform = currenttile.gObject.transform;
            for ( var i = 0; i < curtransform.childCount; i++ )
            {
                curtransform.GetChild (i).gameObject.SetActive (true);
            }
        }
    }

    public static int RandomGenerator( float[] percent ) {
        if( percent.Sum() != 1f )
            return -1;
        else {
            float temp = Random.Range( 0, 1 );
            float[] interval = new float[ percent.Length + 1 ];
            interval[ 0 ] = 0f;
            for( int i = 0; i < percent.Length; i++ ) {
                interval[ i + 1 ] = interval[ i ] + percent[ i ];
                if( interval[ i ] <= temp && temp <= interval[ i + 1 ] )
                    return i;
            }
            return -1;
        }
    }

    public void MoveNextFloor() {
        whichFloor++;
        Debug.Log( "hi" );
        Debug.Log( "씬 수:" + SceneManager.sceneCount );
        SceneManager.LoadScene( "next" );
        Debug.Log( "씬 수:" + SceneManager.sceneCount );
        CurrentMapOfFloor.Clear();
        /*안주운 아이템, npc, 카드키 제거*/
        GameObject neiui = GameObject.Find( "NEIUI" );
        int neiNum = neiui.transform.childCount;
        
        for(int i = 0; i < neiNum; i++ ) {
            if( ! neiui.transform.GetChild(i).CompareTag("ItemPickedUp")) { // 주운 item이 pickedup이 아니라면
                Destroy( neiui.transform.GetChild( i ).gameObject );
                }
        }
        
        while( playerobejct.InventoryList.CheckItem( ItemManager.ItemCategory.WhiteCard ) ) {
            playerobejct.DumpItem( ItemManager.Label.WhiteCard );
        }
        while( playerobejct.InventoryList.CheckItem( ItemManager.ItemCategory.YellowCard ) ) {
            playerobejct.DumpItem( ItemManager.Label.YellowCard );
        }


        StartCoroutine( frameDelay() );
    }
      
    private IEnumerator frameDelay() {
        yield return null;
        Debug.Log( SceneManager.GetActiveScene() );
        parser.GenMapObject( map[ whichFloor ], ref CurrentMapOfFloor );
        floor = map [whichFloor];

        currenttile =
            (from tile in floor
             where tile.x == 0 && tile.y == 0
             select tile).First<MapTile> ();

        var curtransform = currenttile.gObject.transform;
        for ( var i = 0; i < curtransform.childCount; i++ )
        {
            curtransform.GetChild (i).gameObject.SetActive (true);
        }

        gameCamera.transform.position = new Vector3( 0, 0, -10 );
        minimapCamera.transform.position = new Vector3( 0, 0, (float)26.6 );
        playerobejct.transform.position = new Vector3( (float)0.1, -2, 1 );
        xPos = 0;
        yPos = 0;
    }

}