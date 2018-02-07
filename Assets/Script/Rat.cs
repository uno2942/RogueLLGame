using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Enemy {
    private void Start()
    {
        Debug.Log ("시작시작111");
        level = 1;
        attack = 1;
        defense = 1;
        hp = 30;
        gameManager = gameManagerObject.GetComponent<GameManager> ();
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log ("몬스터 공격");
        gameManager.AttackToEnemy (this);
        gameManager.EnemyTurn ();
        gameManager.nextturn ();
    }
}
