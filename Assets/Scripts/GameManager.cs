using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * \brief 게임 전반(턴, 몬스터 등)을 관리하는 코드
 */
public class GameManager : MonoBehaviour {

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
    //@}
    /**
     * This variables are tentatively implemented.
     */
     //@{
    public GameObject ratPrefab;
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
        player = playerObject.GetComponent ("Player") as Player;
        monsterGenLocation = new Vector2 [6];
        monsterGenLocation [0] = new Vector2 (0, 2);
        monsterGenLocation [1] = new Vector2 (-2, 2);
        monsterGenLocation [2] = new Vector2 (2, 2);
        monsterGenLocation [3] = new Vector2 (-3, 2);
        monsterGenLocation [4] = new Vector2 (0, 2);
        monsterGenLocation [5] = new Vector2 (3, 2);
        currentTurn = 0;
        currentSituation = false;
        boardManager = GameObject.Find("BoardManager").GetComponent<BoardManager>();
        itemManager = GameObject.Find ("ItemManager").GetComponent<ItemManager> ();
    }

    // Update is called once per frame
    /** It consistently check whether there is a enemy gameobject in the map.
     */
    void Update()
    {
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
     * When player click an enemy, this function is called.
     * It deals with the decrease of enemy HP and check whether the enemy die after this attack \since the dead enemy should not attack to player.
     * If the enemy died, the gameobject is destoried.
     * \see Rat::OnMouseUpAsButton (It can be modified.)
     */
    /**
     * The selected enemy in the parameter attacks to the player.
     * If the player's HP is less or equal to 0, the player die and the gameobject is destoried.
     * \see EnemyTurn
     */
    public bool AttackToPlayer(Enemy enemy)
    {
        if ( enemy.Hp <= 0 ) return false;
        int damage = 1;
        player.ChangeHp (-damage);
        if(IsDead())
        {
            Destroy (player.gameObject);
            Debug.Log ("포닉스 불닭행");
        }
        return true;
    }
    /**
     * It generates monsters on the board with fixed number of monsters given by parameter.
     * \see Door::OnMouseUpAsButton
     */
    public void GenerateMonsters(int numberOfMonster)
    {
        Vector2 nowPos = new Vector2 (boardManager.XPos * BoardManager.horizontalMovement, boardManager.YPos * BoardManager.verticalMovement);
        switch(numberOfMonster)
        {
            case 0: break;
            case 1:
                Instantiate (ratPrefab, nowPos + monsterGenLocation[0], Quaternion.identity);
                break;
            case 2:
                Instantiate (ratPrefab, nowPos + monsterGenLocation [1], Quaternion.identity);
                Instantiate (ratPrefab, nowPos + monsterGenLocation [2], Quaternion.identity);
                break;
            case 3:
                Instantiate (ratPrefab, nowPos + monsterGenLocation [3], Quaternion.identity);
                Instantiate (ratPrefab, nowPos + monsterGenLocation [4], Quaternion.identity);
                Instantiate (ratPrefab, nowPos + monsterGenLocation [5], Quaternion.identity);
                break;
        }
        if(numberOfMonster >0)
        {
            currentSituation = true;
        }
    }
    /**
     * 프로토 타입을 만들 때 사용한 함수.
     * @todo 더 구현해야 한다.
     */
    public void GenerateBoss() {
        Vector2 nowPos = new Vector2( boardManager.XPos * BoardManager.horizontalMovement, boardManager.YPos * BoardManager.verticalMovement );
    }

    /**
     * 이 함수는 플레어어의 턴을 종류하는 역할을 한다.
     * 이 게임의 턴 진행을 위한 함수. 이 게임의 턴 진행 로직은 다음과 같다.
     * 1. 각 플레이어가 할 수 있는 행동을 구현하는 함수 마지막에서 EndPlayerTurn() 함수를 호출한다.
     * 2. EndPlayerTurn() 함수에서 차례로 CheckPlayerStatus(), EnemyTurn(), CheckEnemyStatus(), AlltheTurnEnd() 함수를 호출한다.
     * 3. 턴을 끝내고 다음 플레이어 행동을 기다린다.
     */
    public void EndPlayerTurn(Unit.Action action) {
        CheckPlayerStatus( action );
    }
    /**
     * 이 함수는 플레이어의 정신력과 배고픔을 먼저 체크하여 환각과 굶주림 판정을 한 후, 플레이어의 버프를 체크하여 효과를 부여한다.
     * 이 게임의 턴 진행을 위한 함수. 이 게임의 턴 진행 로직은 다음과 같다.
     * 1. 각 플레이어가 할 수 있는 행동을 구현하는 함수 마지막에서 EndPlayerTurn() 함수를 호출한다.
     * 2. EndPlayerTurn() 함수에서 차례로 CheckPlayerStatus(), EnemyTurn(), CheckEnemyStatus(), AlltheTurnEnd() 함수를 호출한다.
     * 3. 턴을 끝내고 다음 플레이어 행동을 기다린다.
     */
    private void CheckPlayerStatus( Unit.Action action ) {
        //정신력 체크
        DecreaseMpByTurn();
        if( player.Mp <= 30 && !player.isHallucinated ) {
            player.SetMpZero();
            player.Bufflist.Add( new Hallucinated(-1));
            player.isHallucinated = true;
        }

        if( player.isHallucinated && player.Mp >= 60 ) {
                player.Bufflist.Remove( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hallucinated ) ) ) );
                player.SetMpBy100();
            player.isHallucinated = false;
        }
        //상태이상 체크
        IncreaseHungryByTurn();
        if( player.Hungry >= 100 && !player.isHungry ) {
            player.Bufflist.Add( new Hunger() );
            player.isHungry = true;
        }
        if( player.Hungry >= 130 && !player.isStarved && player.isHungry ) {
            player.Bufflist.Add( new Starve() );
            player.isStarved = true;
        } 
        else if( player.Hungry < 130 && player.isStarved ) {
            player.Bufflist.Remove( player.Bufflist.Find( x => x.GetType().Equals( typeof( Starve ) ) ) );
            player.isStarved = false;
        }
        if(player.Hungry<100 && player.isHungry ) {
            player.Bufflist.Remove( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hunger ) ) ) );
            player.isHungry = false;
        }
        if( player.Hungry < 50 ) {
            player.Bufflist.Add( new Full( -1 ) );
        } else {
            player.Bufflist.Remove( player.Bufflist.Find( x => x.GetType().Equals( typeof( Full ) ) ) );
        }
        Debug.Log( enemyNum );
        
        foreach( Buff buff in player.Bufflist ) {
            buff.BuffWorkTo( player, action );
            if( buff.Count == 0 )
                player.Bufflist.Remove( buff );
        }
        Debug.Log( player.Hp.ToString() + " " + player.Mp.ToString() + " " + player.Hungry );
        if( IsDead() ) {
            Destroy( player.gameObject );
            Debug.Log( "포닉스 불닭행" );
        };
        EnemyTurn();
    }
    /**
    * 적들이 플레이어를 공격하는 함수이다.
    * 이 게임의 턴 진행을 위한 함수. 이 게임의 턴 진행 로직은 다음과 같다.
    * 1. 각 플레이어가 할 수 있는 행동을 구현하는 함수 마지막에서 EndPlayerTurn() 함수를 호출한다.
    * 2. EndPlayerTurn() 함수에서 차례로 CheckPlayerStatus(), EnemyTurn(), CheckEnemyStatus(), AlltheTurnEnd() 함수를 호출한다.
    * 3. 턴을 끝내고 다음 플레이어 행동을 기다린다.
    */
    private void EnemyTurn() {
        int enemyNum = 0;
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
        for( int i = 0; i < enemyList.Length; i++ ) {
            if( enemyList[ i ].GetComponent<Enemy>().EnemyAction.Attack() )
                enemyNum++;
        }
        Debug.Log( enemyNum );

        for( int i = 0; i < enemyNum; i++ ) {
            AttackToPlayer( enemyList[ i ].GetComponent<Enemy>() );
        }
        CheckEnemyStatus();
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
        Enemy enemyTemp;
        int enemyNum=0;

        foreach( GameObject gObject in enemyList ) {
            enemyTemp = gObject.GetComponent<Enemy>();
            foreach( Buff buff in enemyTemp.Bufflist ) {
                buff.BuffWorkTo( enemyTemp, Unit.Action.Default );
                if( buff.Count == 0 )
                    enemyTemp.Bufflist.Remove( buff );
            }
            if( enemyTemp.Hp >= 0 )
                enemyNum++;
        }

        if( enemyNum == 0 && prevMonsterNum != 0 ) {
            if( Equals( enemyList[ 0 ].GetComponent<Enemy>().GetType(), typeof( BoundedCrazy ) ) ) 
                itemManager.DropCard( boardManager.NowPos() );
            else
                itemManager.DropItem( boardManager.NowPos() );
            currentSituation = false;
        }
        prevMonsterNum = enemyNum;
        if( IsDead() ) {
            Destroy( player.gameObject );
            Debug.Log( "포닉스 불닭행" );
        };
        player.InventoryList.IdentifyAllTheInventoryItem();
        AlltheTurnEnd();
    }
    /**
     * 이 함수는 턴의 맨 마지막을 가르킨다.
     * 이 함수는 비어있지만, 필요한 이유는 턴 동안 아무것도 안 하는 함수도 필요할지 모르기 때문이다.
     */
    public void AlltheTurnEnd() {
        if( !( Equals( player.Bufflist.Find( x => x.GetType().Equals( typeof( Stunned ) ) ), null ) ) && player.prevIsStunned == false ) {
            player.isStunned = true;
            player.stunned = player.Bufflist.Find( x => x.GetType().Equals( typeof( Stunned ) ) ) as Stunned;
        } else if( player.stunned.Count == 0 ) {
            player.isStunned = false;
            player.Bufflist.Remove( player.stunned );
        }
    }
    /**
     * 플레이어가 사망하였는 확인한다.
     * \return true일 경우 플레이어가 사망한 것이다.
     */
    private bool IsDead() {
        if( player.Hp <= 0 || player.Hungry >= 100 )
            return true;
        else
            return false;
    }
    /** After the player turn, enemies attack to player.
     * It finds all the enemies in the board and make them attack to player.
     * If there are enemies, it turns currentSituation true. If not, it turns currentSituation false.
     * \see Rat::OnMouseUpAsButton
     */
    

    public void Throw(ItemManager.Label label) {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
        for( int i = 0; i < enemyList.Length; i++ ) {
            ThrowToEnemy( enemyList[ i ].GetComponent<Enemy>(), label );
        }
        if( ItemManager.LabelToCategory( label ) == ItemManager.ItemCategory.LiquidFlameMedicine )
            player.AddBuff( new Burn( 10 ) );
    }

    private void ThrowToEnemy(Enemy enemy, ItemManager.Label label) {
        Capsule capsule = itemManager.LabelToItem( label ) as Capsule;
        capsule.ThrownTo( enemy );
    }
    /**
     * 매 턴에서 상태 이상 체크 시 플레이어의 허기 지수를 올리는 함수입니다.
     */
    private void IncreaseHungryByTurn() {
        int times=1;
        if( player.isFull )
            times *= 2;
        if( Equals( player.weapon.GetType(), typeof( FullPlated ) ) )
            times *= 5;
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
        if( Equals( player.weapon.GetType(), typeof( BloodJacket ) ) )
            player.ChangeMp( -0.8f );
        else if( Equals( player.weapon.GetType(), typeof( CleanDoctorCloth ) ) )
            player.ChangeMp( 1 );
    }
}