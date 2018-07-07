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
    private bool isMental, isAwaken, isRelieve;
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
    void Start()
    {
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
        isMental = false;
    }

    // Update is called once per frame
    /** It consistently check whether there is a enemy gameobject in the map.
     */
    void Update()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
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
    public void AttackToEnemy(Enemy enemy)
    {
        int damage = 10;
        enemy.ChangeHp (-damage);
        if ( enemy.Hp <= 0 )
        {
            Destroy (enemy.gameObject);
            Debug.Log ("적 사망");
        }
    }
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
        if(player.Hp<=0)
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
    public void nextturn()
    {
        Debug.Log (player.Hp);
        bool prevAwaken = isAwaken;
        currentTurn++;
        if (!isMental && player.Mp <= 40 )
        {
            player.ChangeMp (-player.Mp);
            isMental = true;
            player.AddStatus (StatusCheck.StatusEnum.Mental);
        }
        else if(isMental && player.Mp>=60)
        {
            isMental = false;
            player.DeleteStatus (StatusCheck.StatusEnum.Mental);
        }
        else if(isMental)
        {
            player.ChangeMp (1);
        }

        if(player.Hungry ==100)
        {
            player.ChangeHp (-player.Hp);
        }
        else if( player.Hungry >= 80)
        {
            player.DeleteStatus (StatusCheck.StatusEnum.Hunger);
            player.AddStatus (StatusCheck.StatusEnum.Starve);
        }
        else if(player.Hungry>=50)
        {
            player.DeleteStatus (StatusCheck.StatusEnum.Starve);
            player.AddStatus (StatusCheck.StatusEnum.Hunger);
        }


        player.ChangeHungry (1);
        if ( player.isRelieve () ) player.ChangeMp (3);
        player.UpdateStatus ();
        isRelieve = player.isRelieve ();
        isAwaken = player.isAwaken ();
        if ( isAwaken != prevAwaken ) player.ChangeMp (-10);

            Debug.Log ("현재 " + currentTurn + "턴 : 전투상태 " + currentSituation + " 내상태 " + player.Hp + " / " + player.Mp);
        player.debugStatus ();
    }

    /** After the player turn, enemies attack to player.
     * It finds all the enemies in the board and make them attack to player.
     * If there are enemies, it turns currentSituation true. If not, it turns currentSituation false.
     * \see Rat::OnMouseUpAsButton
     */
    public void EnemyTurn()
    {
        int enemyNum = 0;
        GameObject [] enemyList = GameObject.FindGameObjectsWithTag ("Enemy");
        for(int i=0;i<enemyList.Length;i++ )
        {
            if( AttackToPlayer (enemyList [i].GetComponent<Enemy> ()) )
                enemyNum ++ ;
        }

        if( enemyNum == 0 && prevMonsterNum != 0 ) 
        {
            itemManager.DropItem (boardManager.NowPos());
            currentSituation = false;
        }
        prevMonsterNum = enemyNum;
    }

    public void Throw(ItemManager.Label label) {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
        for( int i = 0; i < enemyList.Length; i++ ) {
            ThrowToEnemy( enemyList[ i ].GetComponent<Enemy>(), label );
        }
    }

    private void ThrowToEnemy(Enemy enemy, ItemManager.Label label) {
        Capsule capsule = itemManager.LabelToItem( label ) as Capsule;
        capsule.ThrownTo( enemy );

    }
}