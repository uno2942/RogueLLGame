using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    /**
     * It contains number of passed turns from the beginning of the game.
     */
    private int currentTurn;
    private int prevMonsterNum;
    private bool currentSituation; //true : 싸움
                                   /**
                                    * This variables are tentatively implemented.
                                    * The coder can make a function dealing with the condition of the player and separate this varialbes to the function.
                                    */
    //@{
    public bool isHallucinated=false;
    public bool isHungry = false;
    public bool isStarved = false;
    //@}
    /**
     * It interacts with other Manager gameobject and player gameobject.
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
    public GameObject ratPrefab;
    private Vector2[] monsterGenLocation;
    /**
 * It checks whether the player is in battle or not.
 * If it is true, the player is in battle.
 */
    public bool CurrentSituation
    {
        get
        {
            return currentSituation;
        }
    }
    /** 
 * It contains the fixed location of monster in the field.
 */
    public Vector2[] MonsterGenLocation
    {
        get
        {
            return monsterGenLocation;
        }
    }

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
    /** After the player and enemies' turn, it put all the ... and advance the turn.
     * The currentTurn increases by 1 and condition of player is added and deleted, and the effect of the condition is invoked in this function.
     * There is a debug log showing the turn numbers.
     * \see Rat::OnMouseUpAsButton and
     * \see Door:OnMouseUpAsButton
     */

    public void EndPlayerTurn() {
        CheckPlayerStatus();
    }

    private void CheckPlayerStatus() {
        //정신력 체크
        player.ChangeMp( -0.5f );
        if( player.Mp <= 30 && !isHallucinated ) {
            player.SetMpZero();
            player.Bufflist.Add( new Hallucinated(-1));
            isHallucinated = true;
        }

        if( isHallucinated ) {
            player.ChangeMp( 1.2f );
            if( player.Mp >= 60 )
                player.Bufflist.Remove( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hallucinated ) ) ) );
        }
        //상태이상 체크
        player.ChangeHungry( 1 );
        if( player.Hungry >= 80 && !isStarved && isHungry ) {
            player.Bufflist.Add( new Starve() );
            isStarved = true;
        } 
        else if( player.Hungry >= 50 && !isHungry ) {
            player.Bufflist.Add( new Hunger() );
            isHungry = true;
        } 
        else if( player.Hungry < 80 && isStarved ) {
            player.Bufflist.Remove( player.Bufflist.Find( x => x.GetType().Equals( typeof( Starve ) ) ) );
            isStarved = false;
        }
        else if(player.Hungry<50 && isHungry) {
            player.Bufflist.Remove( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hunger ) ) ) );
            isHungry = false;
        }
        
        foreach( Buff buff in player.Bufflist ) {
            buff.BuffWorkTo( player );
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

    private void EnemyTurn() {
        int enemyNum = 0;
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
        for( int i = 0; i < enemyList.Length; i++ ) {
            if( enemyList[ i ].GetComponent<Enemy>().Action.Attack() )
                enemyNum++;
        }
        Debug.Log( enemyNum );

        for( int i = 0; i < enemyNum; i++ ) {
            AttackToPlayer( enemyList[ i ].GetComponent<Enemy>() );
        }
        CheckEnemyStatus();
    }

    public void CheckEnemyStatus() {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
        Enemy enemyTemp;
        int enemyNum=0;

        foreach( GameObject gObject in enemyList ) {
            enemyTemp = gObject.GetComponent<Enemy>();
            foreach( Buff buff in enemyTemp.Bufflist ) {
                buff.BuffWorkTo( player );
                if( buff.Count == 0 )
                    enemyTemp.Bufflist.Remove( buff );
            }
            if( enemyTemp.Hp >= 0 )
                enemyNum++;
        }

        /**
         * 보스를 잡은 경우 카드를 떨어트린다.
         * @todo 더 짜야한다.
         */
        if( enemyNum == 0 && prevMonsterNum != 0 ) {
            if( Equals(enemyList[0].GetComponent<Enemy>().GetType(), typeof(BoundedCrazy)) )
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

    public void AlltheTurnEnd() {

    }

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
}