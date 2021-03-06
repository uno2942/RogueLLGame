﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * \brief 게임 전반(턴, 몬스터 등)을 관리하는 코드
 */
public class GameManager : MonoBehaviour {

    private bool playerTurn;
    private bool enemyAttackTurn;
    private bool enemyCheckTurn;
    public bool ThrowFlag = false;
    public GameObject ThrowObject;
    public int ThrowIndex;
    private ItemManager.Label throwLabel;
    private Unit.Action action;
    private int currentTurn; /**< It contains number of passed turns from the beginning of the game. */
    
    private int prevMonsterNum;/**<
                                * 이전 턴에서의 몬스터 수를 저장한다. 이는 플레이어가 몬스터를 잡은 직후를 체크하기 위함이다.
                                * 예를 들어 현재 몬스터의 수가 0이고, 이전 몬스터의 수가 0이 아니면 이는 플레이어가 몬스터를 전부 잡은 것을 의미한다.
                                */
    private bool currentSituation;
    public bool CurrentSituation
    {
        get
        {
            return currentSituation;
        }
    }    /**<
                                         * 현재 플레이어가 전투 중인지 확인한다.
                                         * true일 경우 플레이어는 전투 중이다. 이를 통해 문의 개폐 여부 등을 제어한다.
                                         * \see Door::OnMouseUpAsButton
                                         */

    
    /**
     * 게임 전반을 관리해야 하기 때문에 다른 매니저와 플레이어와 상호작용 할 수 있도록 하는 변수
     */
    //@{
    public GameObject playerObject;
    private Player player;
    private BoardManager boardManager;
    private ItemManager itemManager;
    private MessageMaker messageMaker;

    //@}
    /**
     * This variables are tentatively implemented.
     */
     //@{
    public GameObject ratPrefab;
    public GameObject dogPrefab;
    public GameObject humanPrefab;
    public GameObject boundedCrazyPrefab;
    public GameObject gunnerPrefab;
    public GameObject nurseprefab;
    public GameObject angrydogprefab;
    public GameObject gposclubprefab;
    public GameObject principalprefab;

    public GameObject[] npcPrefab;

    private Vector2[] monsterGenLocation;
    //@}


    public Vector2[] MonsterGenLocation
    {
        get
        {
            return monsterGenLocation;
        }
    } /**< It contains the fixed location of monster in the field. */

    // Use this for initialization

    /**
    * It initiate the monsterGenLocation and currentTurn to 0 (resp. situtation to false)
    */
    void Start() {
        playerTurn=true;
        enemyAttackTurn=false;
        enemyCheckTurn=false;
        player = playerObject.GetComponent ("Player") as Player;
        monsterGenLocation = new Vector2 [6];
        monsterGenLocation [0] = new Vector2 (0, 2);
        monsterGenLocation [1] = new Vector2 (-2, 2);
        monsterGenLocation [2] = new Vector2 (2, 2);
        monsterGenLocation [3] = new Vector2 (-3, 2);
        monsterGenLocation [4] = new Vector2 (3, 2);
        monsterGenLocation [5] = new Vector2 (0, 2);
        currentTurn = 0;
        currentSituation = false;
        boardManager = GameObject.Find("BoardManager").GetComponent<BoardManager>();
        itemManager = GameObject.Find ("ItemManager").GetComponent<ItemManager> ();
        messageMaker = GameObject.Find( "Logger" ).GetComponent<MessageMaker>();
    }

    // Update is called once per frame
    /** It consistently check whether there is a enemy gameobject in the map.
     */
    void Update()
    {
        if(playerTurn==false && enemyAttackTurn==false && enemyCheckTurn==false)
            CheckPlayerStatus( action );
        else if(playerTurn==false && enemyAttackTurn==true && enemyCheckTurn==false)
            EnemyTurn();
        else if(playerTurn==false && enemyAttackTurn==false && enemyCheckTurn==true)
            CheckEnemyStatus();
        //수정
        if(player.isStunned==true) {
            CheckPlayerStatus(Unit.Action.Rest);
            player.stunned.BuffWorkTo(player, Unit.Action.Rest); // 카운트 깍는 용
        }
    //    GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
        /*if( 0 == enemyList.Length ) {
            currentSituation = false;
        } else {

        } 
        */
    //일단 문이 닫혀 있는 걸로 적어 놓을게요.

}

    /**
 * 이 함수는 플레어어의 턴을 종류하는 역할을 한다.
 * 이 게임의 턴 진행을 위한 함수. 이 게임의 턴 진행 로직은 다음과 같다.
 * 1. 각 플레이어가 할 수 있는 행동을 구현하는 함수 마지막에서 EndPlayerTurn() 함수를 호출한다.
 * 2. EndPlayerTurn() 함수에서 차례로 CheckPlayerStatus(), EnemyTurn(), CheckEnemyStatus(), AlltheTurnEnd() 함수를 호출한다.
 * 3. 턴을 끝내고 다음 플레이어 행동을 기다린다.
 */
    public void EndPlayerTurn( Unit.Action _action ) {
        playerTurn = false;
        action = _action;
    }
    /**
     * 이 함수는 플레이어의 정신력과 배고픔을 먼저 체크하여 환각과 굶주림 판정을 한 후, 플레이어의 버프를 체크하여 효과를 부여한다.
     * 이 게임의 턴 진행을 위한 함수. 이 게임의 턴 진행 로직은 다음과 같다.
     * 1. 각 플레이어가 할 수 있는 행동을 구현하는 함수 마지막에서 EndPlayerTurn() 함수를 호출한다.
     * 2. EndPlayerTurn() 함수에서 차례로 CheckPlayerStatus(), EnemyTurn(), CheckEnemyStatus(), AlltheTurnEnd() 함수를 호출한다.
     * 3. 턴을 끝내고 다음 플레이어 행동을 기다린다.
     */
    private void CheckPlayerStatus( Unit.Action _action ) {
        //정신력 체크
        DecreaseMpByTurn();
        //1층 보스시 추가감소
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
        GameObject [] bossList = GameObject.FindGameObjectsWithTag ("Boss");

        foreach( var bossObject in bossList )
        {
            var boss = bossObject.GetComponent<Boss> ();
            boss.EnemyAction.Other ();
        }
        
        bool tmpHallucinated = player.isHallucinated;
        if( player.Mp <= 30 && !player.isHallucinated ) {
            player.SetMpZero();
            player.AddBuff( new Hallucinated( -1 ) );
            player.isHallucinated = true;
        }

        if( player.isHallucinated && player.Mp >= 60 ) {
            player.DeleteBuff(new Hallucinated (1) );
            player.SetMpBy100();
            player.isHallucinated = false;
        }
        if(tmpHallucinated != player.isHallucinated ) {
            foreach( var bossObject in bossList )
            {
                bossObject.GetComponent<Boss> ().ChangeStatus (player.isHallucinated);
            }
            foreach( var enemyObject in enemyList ) {//환각에 따른 몹 상태변화
                enemyObject.GetComponent<Enemy>().ChangeStatus( player.isHallucinated );
            }
        }


        //상태이상 체크
        IncreaseHungryByTurn();
        if( IsDead() ) {
            Buff B = new Starve();
            messageMaker.MakeDeathMessage( B );
            KillPlayer();
            return;
        }
        if( player.Hungry < 60 ) {
            if( player.HungryPrevious >= 160 ) {
                player.DeleteBuff( new Hunger() );
                player.isHungry = false;
                player.AddBuff( new Full( -1 ) );
                player.isFull = true;
            } else if( player.HungryPrevious >= 60 ) {
                player.AddBuff( new Full( -1 ) );
                player.isFull = true;
            }
        } else if( player.Hungry < 160 ) {
            if( player.HungryPrevious < 60 ) {
                player.DeleteBuff( new Full( -1 ) );
                player.isFull = false;
            } else if( player.HungryPrevious >= 210 ) {
                player.DeleteBuff( new Starve() );
                player.isStarved = false;
            } else if( player.HungryPrevious >= 160 ) {
                player.DeleteBuff( new Hunger() );
                player.isHungry = false;
            }
        } else if( player.Hungry < 210 ) {
            if( player.HungryPrevious < 160 ) {
                player.AddBuff( new Hunger() );
                player.isHungry = true;
            } else if( player.HungryPrevious >= 210 ) {
                player.DeleteBuff( new Starve() );
                player.isStarved = false;
                player.AddBuff( new Hunger() );
                player.isHungry = true;
            }
        } else if( player.HungryPrevious < 210 ) {
            player.DeleteBuff( new Hunger() );
            player.isHungry = false;
            player.AddBuff( new Starve() );
            player.isStarved = true;
        }
        player.SyncHungry();

        List<Buff> buffToDelete = new List<Buff>();

        foreach( Buff buff in player.Bufflist ) {
            Debug.Log( buff );
            buff.BuffWorkTo( player, _action );
            if( buff.Count == 0 )
                buffToDelete.Add( buff );
            if( IsDead() ) {
                messageMaker.MakeDeathMessage( buff );
                KillPlayer();
            }
        }

        foreach( Buff buffToDel in buffToDelete )
            player.DeleteBuff( buffToDel );

        Debug.Log( player.Hp.ToString() + " " + player.Mp.ToString() + " " + player.Hungry );
        Debug.Log( "ATK : " + player.Attack + ", DEF : " + player.Defense );
        if( IsDead() )
        {
            KillPlayer();
        };
        if ( _action == Unit.Action.Move )
        {
            playerTurn = true;
            return;
        }
        else
        {
            enemyAttackTurn = true;
            return;
        }
    }
    /**
    * 적들이 플레이어를 공격하는 함수이다.
    * 이 게임의 턴 진행을 위한 함수. 이 게임의 턴 진행 로직은 다음과 같다.
    * 1. 각 플레이어가 할 수 있는 행동을 구현하는 함수 마지막에서 EndPlayerTurn() 함수를 호출한다.
    * 2. EndPlayerTurn() 함수에서 차례로 CheckPlayerStatus(), EnemyTurn(), CheckEnemyStatus(), AlltheTurnEnd() 함수를 호출한다.
    * 3. 턴을 끝내고 다음 플레이어 행동을 기다린다.
    */
    private void EnemyTurn() {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
        GameObject [] bossList = GameObject.FindGameObjectsWithTag ("Boss");
        foreach(var bossObject in bossList)
        {
            if ( bossObject.GetComponent<Boss> () is AngryDog )
            {
                var enemy = bossObject.GetComponent<Boss> ();
                enemy.EnemyAction.Attack ();
                enemy.EnemyAction.Attack ();
                if ( player.isHallucinated )
                    enemy.EnemyAction.Attack ();
            }
            else
                bossObject.GetComponent<Boss> ().EnemyAction.Attack ();
            if ( IsDead () )
            {
                messageMaker.MakeDeathMessage (bossObject.GetComponent<Boss> (), player);
                KillPlayer ();
            }
        }
        foreach( var enemyObject in enemyList )
        {
            enemyObject.GetComponent<Enemy> ().EnemyAction.Attack ();

            if(IsDead()) {
                messageMaker.MakeDeathMessage( enemyObject.GetComponent<Enemy>(), player );
                KillPlayer();
            }
        }
        enemyAttackTurn = false;
        enemyCheckTurn = true;
    }
    /**
    * 적들에 걸린 상태이상(버프)를 체크하여 효과를 입히는 함수이다.
    * 이 게임의 턴 진행을 위한 함수. 이 게임의 턴 진행 로직은 다음과 같다.
    * 1. 각 플레이어가 할 수 있는 행동을 구현하는 함수 마지막에서 EndPlayerTurn() 함수를 호출한다.
    * 2. EndPlayerTurn() 함수에서 차례로 CheckPlayerStatus(), EnemyTurn(), CheckEnemyStatus(), AlltheTurnEnd() 함수를 호출한다.
    * 3. 턴을 끝내고 다음 플레이어 행동을 기다린다.
    */
    public void CheckEnemyStatus() {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
        GameObject [] bossList = GameObject.FindGameObjectsWithTag ("Boss");
        Boss bossTemp;
        Enemy enemyTemp;
        int enemyNum = 0;
        int bossNum = 0;

        foreach ( GameObject gObject in bossList )
        {
            bossTemp = gObject.GetComponent<Boss> ();
            foreach ( Buff buff in bossTemp.Bufflist )
            {
                buff.BuffWorkTo (bossTemp, Unit.Action.Default);
                if ( buff.Count == 0 )
                    bossTemp.DeleteBuff (buff);
            }
        }

        foreach ( GameObject gObject in enemyList ) {
            enemyTemp = gObject.GetComponent<Enemy>();
            foreach( Buff buff in enemyTemp.Bufflist ) {
                buff.BuffWorkTo( enemyTemp, Unit.Action.Default );
                if( buff.Count == 0 )
                    enemyTemp.DeleteBuff( buff );
            }
        }
        enemyNum = enemyList.Length;
        if( enemyNum == 0 ) {
            //            if( Equals( enemyList[ 0 ].GetComponent<Enemy>().GetType(), typeof( BoundedCrazy ) ) ) 
            //                itemManager.DropCard( boardManager.NowPos() );
            //            else
            currentSituation = false;
        }
        prevMonsterNum = enemyNum;
        if( IsDead() )
        {
            KillPlayer();
        };
        player.InventoryList.IdentifyAllTheInventoryItem();
        enemyCheckTurn = false;
        playerTurn = true;
    }
    /**
     * 이 함수는 턴의 맨 마지막을 가르킨다.
     * 이 함수는 비어있지만, 필요한 이유는 턴 동안 아무것도 안 하는 함수도 필요할지 모르기 때문이다.
     */
    public void AlltheTurnEnd() {
        //수정 필요
        if( !( Equals( player.Bufflist.Find( x => x.GetType().Equals( typeof( Stunned ) ) ), null ) ) && player.prevIsStunned == false ) {
            player.isStunned = true;
            player.stunned = player.Bufflist.Find( x => x.GetType().Equals( typeof( Stunned ) ) ) as Stunned;
        } else if( player.isStunned == false ) {
            player.isStunned = false;
            player.DeleteBuff( player.stunned );
        }
    }
    /**
     * When player click an enemy, this function is called.
     * It deals with the decrease of enemy HP and check whether the enemy die after this attack \since the dead enemy should not attack to player.
     * If the enemy died, the gameobject is destoried.
     * \see Rat::OnMouseUpAsButton (It can be modified.)
     */

    /**
     * It generates monsters on the board with fixed number of monsters given by parameter.
     * \see Door::OnMouseUpAsButton
     */
     public void GenerateMonstersAndItems(int x, int y)
    {
        Vector2 nowPos = new Vector2 (boardManager.XPos * BoardManager.horizontalMovement, boardManager.YPos * BoardManager.verticalMovement);
        MapTile maptile = boardManager.CurrentMapOfFloor [new MapGenerator.Coord (x, y)];
        Debug.Log ("적 수: " + maptile.enemyList.Count + ", 아이템 수: " + maptile.itemList.Count);
        if ( maptile.enemyList.Count == 0 || maptile.itemList.Count == 0 )
        {
            GenerateItems (x, y);
            GenerateMonsters (x, y);
        }
        else
        {
            switch ( maptile.enemyList.Count + maptile.itemList.Count )
            {
                case 0: return;
                case 2://일반 적 사람 한명 + 링겔액인 경우.
                    InstantiateMonster (maptile.enemyList [0], monsterGenLocation [1] + nowPos);
                    itemManager.InstantiateItem (maptile.itemList [0], monsterGenLocation [2] + nowPos);
                    break;
                case 3://적 2기 + 노란 키카드인 경우.
                    InstantiateMonster (maptile.enemyList [0], monsterGenLocation [3] + nowPos);
                    itemManager.InstantiateItem (maptile.itemList [0], monsterGenLocation [4] + nowPos);
                    itemManager.InstantiateItem (maptile.itemList [1], monsterGenLocation [5] + nowPos);
                    break;
                default: return;
            }

            maptile.enemyList.Clear ();
            maptile.itemList.Clear ();
        }
    }

    public void GenerateMonsters(int x, int y)
    {
        Vector2 nowPos = new Vector2( boardManager.XPos * BoardManager.horizontalMovement, boardManager.YPos * BoardManager.verticalMovement );
        MapTile maptile = boardManager.CurrentMapOfFloor[ new MapGenerator.Coord( x, y ) ];
        Debug.Log( "적 수: " + maptile.enemyList.Count );
        switch(  maptile.enemyList.Count) {
        case 0: return;
        case 1:
            InstantiateMonster( maptile.enemyList[ 0 ], monsterGenLocation[ 0 ]+nowPos );
            break;
        case 2:
            InstantiateMonster( maptile.enemyList[ 0 ], monsterGenLocation[ 1 ] + nowPos );
            InstantiateMonster( maptile.enemyList[ 1 ], monsterGenLocation[ 2 ] + nowPos );
            break;
        case 3:
            InstantiateMonster( maptile.enemyList[ 0 ], monsterGenLocation[ 3 ] + nowPos );
            InstantiateMonster( maptile.enemyList[ 1 ], monsterGenLocation[ 4 ] + nowPos );
            InstantiateMonster( maptile.enemyList[ 2 ], monsterGenLocation[ 5 ] + nowPos );
            break;
        case 5:
            Vector2 [] GenPos = new Vector2 [6];
            for ( var i = 0; i < 6; i++ )
            {
                GenPos [i] = new Vector2 (-5 + 2 * i, 0);
                InstantiateMonster (maptile.enemyList [i], GenPos [i] + nowPos);
            }
            break;
        default:
            if( maptile.enemyList.Count < 0 ) {
                Debug.Log( "방에 적 수 음수인거 실화냐" );
                break;
            } else if( maptile.enemyList.Count < 5 ) {
                for( var e = 0; e < maptile.enemyList.Count; e++ ) {
                    InstantiateMonster( maptile.enemyList[ e ], monsterGenLocation[ e ] );
                }
                break;
            } else {
                Debug.Log( "Too Much Monster to Generate" );
                break;
            }                        
        }
        currentSituation = true;
        maptile.enemyList.Clear();
                
    }


    public void GenerateItems(int x, int y ) {
        Vector2 nowPos = new Vector2( boardManager.XPos * BoardManager.horizontalMovement, boardManager.YPos * BoardManager.verticalMovement );
        MapTile maptile = boardManager.CurrentMapOfFloor[ new MapGenerator.Coord( x, y ) ];
        Debug.Log( "아이템 개수: " + maptile.itemList.Count );
        switch( maptile.itemList.Count ) {
        case 0: return;
        case 1:
            itemManager.InstantiateItem( maptile.itemList[0], monsterGenLocation[ 0 ] + nowPos );
            break;
        case 2:
            itemManager.InstantiateItem( maptile.itemList[ 0 ], monsterGenLocation[ 1 ] + nowPos );
            itemManager.InstantiateItem( maptile.itemList[ 1 ], monsterGenLocation[ 2 ] + nowPos );
            break;
        case 3:
            itemManager.InstantiateItem( maptile.itemList[ 0 ], monsterGenLocation[ 3 ] + nowPos );
            itemManager.InstantiateItem( maptile.itemList[ 1 ], monsterGenLocation[ 4 ] + nowPos );
            itemManager.InstantiateItem( maptile.itemList[ 2 ], monsterGenLocation[ 5 ] + nowPos );
            break;
        default:
            if( maptile.itemList.Count < 0 ) {
                Debug.Log( "방에 아이템 음수개 실화냐" );
                break;
            } else {
                for( var e = 0; e < maptile.itemList.Count; e++ ) {
                    if( e < 5 )
                        itemManager.InstantiateItem( maptile.itemList[ e ], monsterGenLocation[ e ] + nowPos);
                    else
                        itemManager.InstantiateItem( maptile.itemList[ 0 ], monsterGenLocation[ 0 ] + nowPos);
                }
                break;
            }
        }

        maptile.itemList.Clear();
        
    }

    public void GenerateNPCs( int x, int y ) {
        Vector2 nowPos = new Vector2( boardManager.XPos * BoardManager.horizontalMovement, boardManager.YPos * BoardManager.verticalMovement );
        MapTile maptile = boardManager.CurrentMapOfFloor[ new MapGenerator.Coord( x, y ) ];
        Debug.Log( "NPC 수: " + maptile.NPCList.Count );
        switch( maptile.NPCList.Count ) {
        case 0: return;
        case 1:
            InstantiateNPC( maptile.NPCList[ 0 ], monsterGenLocation[ 0 ] + nowPos );
            break;
        case 2:
            InstantiateNPC( maptile.NPCList[ 0 ], monsterGenLocation[ 1 ] + nowPos );
            InstantiateNPC( maptile.NPCList[ 1 ], monsterGenLocation[ 2 ] + nowPos );
            break;
        case 3:
            InstantiateNPC( maptile.NPCList[ 0 ], monsterGenLocation[ 3 ] + nowPos );
            InstantiateNPC( maptile.NPCList[ 1 ], monsterGenLocation[ 4 ] + nowPos );
            InstantiateNPC( maptile.NPCList[ 2 ], monsterGenLocation[ 5 ] + nowPos );
            break;
        default: break;
        }

        maptile.NPCList.Clear();

    }


    private void InstantiateMonster(BoardManager.EnemyType eType, Vector2 location ) {
        switch(eType){
            case BoardManager.EnemyType.Dog: Instantiate( dogPrefab, location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
            case BoardManager.EnemyType.Human: Instantiate( humanPrefab, location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
            case BoardManager.EnemyType.Rat: Instantiate( ratPrefab, location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
            case BoardManager.EnemyType.BoundedCrazy: Instantiate( boundedCrazyPrefab, location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
            case BoardManager.EnemyType.Gunner: Instantiate(gunnerPrefab, location, Quaternion.identity, GameObject.Find("NEIUI").transform); break;
            case BoardManager.EnemyType.Nurse: Instantiate(nurseprefab, location, Quaternion.identity, GameObject.Find ("NEIUI").transform); break;
            case BoardManager.EnemyType.AngryDog: Instantiate (angrydogprefab, location, Quaternion.identity, GameObject.Find ("NEIUI").transform); break;
            case BoardManager.EnemyType.GPOSClub: Instantiate (gposclubprefab, location, Quaternion.identity, GameObject.Find ("NEIUI").transform); break;
            case BoardManager.EnemyType.HospitalDirector: Instantiate (principalprefab, location, Quaternion.identity, GameObject.Find ("NEIUI").transform); break;
            default: break;
        }
    }
    private void InstantiateNPC( BoardManager.NPCType nType, Vector2 location ) {
        switch( nType ) {
        case BoardManager.NPCType.CapsuleDespenser: Instantiate( npcPrefab[ 0 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case BoardManager.NPCType.InjectorCollector: Instantiate( npcPrefab[ 1 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case BoardManager.NPCType.MedicalBox: Instantiate( npcPrefab[ 2 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case BoardManager.NPCType.MedicineMaster: Instantiate( npcPrefab[ 3 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case BoardManager.NPCType.MentalDoctor  : Instantiate( npcPrefab[ 4 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        

        default: break;
        }
    }


    /**
     * 플레이어가 사망하였는 확인한다.
     * \return true일 경우 플레이어가 사망한 것이다.
     */
    private bool IsDead() {
        if( player.Hp <= 0 || player.Hungry >= 250 )
            return true;
        else
            return false;
    }
    /** After the player turn, enemies attack to player.
     * It finds all the enemies in the board and make them attack to player.
     * If there are enemies, it turns currentSituation true. If not, it turns currentSituation false.
     * \see Rat::OnMouseUpAsButton
     */
    
    /**
    * @todo 던지는 상황에 대한 구현 필요
     */
/*
    public void Throw(ItemManager.Label label) {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
        GameObject [] bossList = GameObject.FindGameObjectsWithTag ("Boss");
        for(int i = 0; i < bossList.Length;i++ )
        {
            ThrowToEnemy (bossList [i].GetComponent<Enemy> (), label);
        }
        for( int i = 0; i < enemyList.Length; i++ ) {
            ThrowToEnemy( enemyList[ i ].GetComponent<Enemy>(), label );
        }*/

    public void Throw(ItemManager.Label label, int index) {
        ThrowFlag = true;
        throwLabel = label;
        ThrowIndex = index;

    }

    public void ThrowToEnemy(Enemy enemy) {
        GameObject.Find( "GameManager" ).GetComponent<GameManager>().ThrowFlag = false;
        player.GetInventoryList().isDialogBoxOn = false;
        Destroy( ThrowObject );
        player.InventoryList.itemManager.ItemIdentify( throwLabel );
        player.InventoryList.IdentifyAllTheInventoryItem();
        GameObject.Find( System.Enum.GetName( typeof( ItemManager.Label ), throwLabel ) + "(Clone)" ).GetComponent<ItemECS>().isUse = true;
        GameObject.Find(System.Enum.GetName(typeof(ItemManager.Label), throwLabel ) + "(Clone)" ).GetComponent<ItemECS>().isThrow=true;
        GameObject.Find(System.Enum.GetName(typeof(ItemManager.Label), throwLabel ) + "(Clone)" ).GetComponent<ItemECS>().enemies.Add(enemy);
        player.DumpItem( ThrowIndex );
    }
    /**
     * 매 턴에서 상태 이상 체크 시 플레이어의 허기 지수를 올리는 함수입니다.
     */
    private void IncreaseHungryByTurn() {
        int times=1;
        if( player.isFull )
            times *= 2;
        if( Equals( player.weapon?.GetType(), typeof( FullPlated ) ) )
            times *= 5;
        if(player.armor is Tshirts) {
            int dice = Random.Range( 0, 5 );
            if(dice!=0 )
                player.ChangeHungry( 1 * times );
            return;
        }
        player.ChangeHungry( 1 * times );
    }
    /**
     * 매 턴에서 상태 이상 체크 시 플레이어의 정신력 지수를 바꾸는 함수입니다.
     * 층 별로 정신력 지수가 바뀌는 정도와 플레이어가 가지고 있는 무기/갑옷에 따른 정신력 변화만 처리합니다.(공격 시 바뀌는 정신력 지수는 여기서 처리 하지 않음.)
     */
    private void DecreaseMpByTurn() {
        if( !player.isHallucinated ) {
            switch( boardManager.WhichFloor ) {
            case 0:
            case 1: player.ChangeMp( -0.5f ); break;
            case 2:
            case 3: player.ChangeMp( -1f ); break;
            case 4:
            case 5: player.ChangeMp( -1.4f ); break;
            }
        }
        else {
            switch( boardManager.WhichFloor ) {
            case 0:
            case 1: 
            case 2: player.ChangeMp( 1.2f ); break;
            case 3:
            case 4:
            case 5: player.ChangeMp( 0.8f ); break;
            }
        }
        if( Equals( player.armor?.GetType(), typeof( BloodJacket ) ) )
            player.ChangeMp( -0.8f );
        else if( Equals( player.armor?.GetType(), typeof( CleanDoctorCloth ) ) )
            player.ChangeMp( 1 );
    }

    public void KillEnemy(Enemy enemy ) {
        if(enemy is Dog)
            boardManager.CurrentMapOfFloor[ new MapGenerator.Coord( boardManager.XPos, boardManager.YPos ) ].enemyList.Remove(BoardManager.EnemyType.Dog);
        else if(enemy is Human)
            boardManager.CurrentMapOfFloor[ new MapGenerator.Coord( boardManager.XPos, boardManager.YPos ) ].enemyList.Remove( BoardManager.EnemyType.Human );
        else if(enemy is Rat)
            boardManager.CurrentMapOfFloor[ new MapGenerator.Coord( boardManager.XPos, boardManager.YPos ) ].enemyList.Remove( BoardManager.EnemyType.Rat );
        Destroy( enemy.gameObject );
    }

    public void KillPlayer() {
        Destroy( player.gameObject );
        SceneManager.LoadScene( "playerDie" );
        Destroy( GameObject.Find( "GameManager" ) );
        Destroy( GameObject.Find( "ItemManager" ) );
        Destroy( GameObject.Find( "BoardManager" ) );
        Destroy( GameObject.Find( "PlayerUI" ) );
        Destroy( GameObject.Find( "InventoryUI" ) );
        Destroy( GameObject.Find( "MinimapCamera" ) );
        Destroy( GameObject.Find( "NEIUI" ) );
        Destroy( GameObject.Find( "Main Camera" ) );
        Destroy( GameObject.Find( "EventSystem" ) );
        Debug.Log( "포닉스 불닭행" );
    }

}