using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Enemy {
    private void Start()
    {
        Debug.Log ("시작시작111");
        level = 1;
        attack = 1;
        defense = 1;
        hp = 30;
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log ("asdf");
        gameManager.AttackToEnemy (this);
        gameManager.EnemyTurn ();
        gameManager.nextturn ();
    }
}
