using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentTurn = 0;
    private bool currentSituation = true; //true : 싸움
    
    public GameObject playerObject;
    private Player player;
    public GameObject ratPrefab;

    private Vector2[] monsterGenTransform;
    // Use this for initialization
    void Start()
    {
        player = playerObject.GetComponent ("Player") as Player;
        monsterGenTransform = new Vector2 [6];
        monsterGenTransform [0] = new Vector2 (0, 2);
        monsterGenTransform [1] = new Vector2 (-2, 2);
        monsterGenTransform [2] = new Vector2 (2, 2);
        monsterGenTransform [3] = new Vector2 (-3, 2);
        monsterGenTransform [4] = new Vector2 (0, 2);
        monsterGenTransform [5] = new Vector2 (3, 2);
    }

    // Update is called once per frame
    void Update()
    {

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
        switch(numberOfMonster)
        {
            case 0: break;
            case 1:
                Instantiate (ratPrefab, monsterGenTransform[0], Quaternion.identity);
                break;
            case 2:
                Instantiate (ratPrefab, monsterGenTransform [1], Quaternion.identity);
                Instantiate (ratPrefab, monsterGenTransform [2], Quaternion.identity);
                break;
            case 3:
                Instantiate (ratPrefab, monsterGenTransform [3], Quaternion.identity);
                Instantiate (ratPrefab, monsterGenTransform [4], Quaternion.identity);
                Instantiate (ratPrefab, monsterGenTransform [5], Quaternion.identity);
                break;
        }
    }

    public void nextturn()
    {
        Debug.Log ("Turn " + currentTurn + "  내 체력 : " + player.Hp);
        currentTurn++;
    }
    public void EnemyTurn()
    {

        Debug.Log ("적턴 시작");
        GameObject [] enemyList = GameObject.FindGameObjectsWithTag ("Enemy");
        Debug.Log (enemyList.Length);
        for(int i=0;i<enemyList.Length;i++ )
        {
            AttackToPlayer (enemyList [i].GetComponent<Enemy>());
        }
        Debug.Log ("적턴 끝");
    }
}