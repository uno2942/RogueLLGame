using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * /brief It is the Rat enemy class.
 */
public class Rat : Enemy {
    /** 
     * There is a debug code.
     */
    private void Start()
    {
        Debug.Log ("시작시작111");
        level = 1;
        attack = 1;
        defense = 1;
        hp = 30;
    }
    /** 
 * There is a debug code.
 * When player clicked this gameobject, player attack to this enemy, and turn of the game flows.
 */
    private void OnMouseUpAsButton()
    {
        Debug.Log( "asdf" );
        gameManager.AttackToEnemy (this);
        gameManager.EnemyTurn ();
        gameManager.nextturn ();
    }
}
