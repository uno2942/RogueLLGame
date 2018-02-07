using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentTurn;
    private bool currentSituation; //true : 싸움

    public GameObject playerObject;
    private Player player;
    // Use this for initialization
    void Start()
    {
        player = playerObject.GetComponent ("Player") as Player;
        currentTurn = 0;
        currentSituation = true;
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
        enemy.changeHp (-damage);
        if ( enemy.Hp <= 0 )
        {
            Destroy (enemy.gameObject);
            Debug.Log ("적 사망");
        }
        
    }

    public void AttackToPlayer(Enemy enemy)
    {
        int damage = 50;
        player.changeHp (-damage);
        if(player.Hp<=0)
        {
            Destroy (player.gameObject);
            Debug.Log ("포닉스 불닭행");
        }
    }

    public void GenerateMonsters(int numberOfMonster)
    {

    }

    public void nextturn()
    {
        Debug.Log ("Turn " + currentTurn + "  내 체력 : " + player.Hp);
        currentTurn++;
    }
    public void EnemyTurn()
    {
        GameObject [] enemyList = GameObject.FindGameObjectsWithTag ("Enemy");
        Debug.Log (enemyList.Length);
        for(int i=0;i<enemyList.Length;i++ )
        {
            AttackToPlayer (enemyList [i].GetComponent<Enemy>());
        }
    }
}