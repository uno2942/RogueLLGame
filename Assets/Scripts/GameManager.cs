using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentTurn;
    private bool currentSituation; //true : 싸움
    private bool isMental, isAwaken, isRelieve;
    public GameObject playerObject;
    private Player player;
    public GameObject ratPrefab;
    private BoardManager boardManager;
    private ItemManager itemManager;
    private Vector2[] monsterGenLocation;

    public bool CurrentSituation
    {
        get
        {
            return currentSituation;
        }
    }

    public Vector2[] MonsterGenLocation
    {
        get
        {
            return monsterGenLocation;
        }
    }

    // Use this for initialization
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
        itemManager.DropItem( new Vector2( 0, 0 ) );
    }

    // Update is called once per frame
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

    public void nextturn()
    {
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
    public void EnemyTurn()
    {
        int enemyNum = 0;
        GameObject [] enemyList = GameObject.FindGameObjectsWithTag ("Enemy");
        Debug.Log (enemyList.Length);
        for(int i=0;i<enemyList.Length;i++ )
        {
            if( AttackToPlayer (enemyList [i].GetComponent<Enemy> ()) )
                enemyNum ++ ;
        }

        if(enemyNum==0)
        {
            //itemManager.dropItem (1);
            currentSituation = false;
        }
    }
}