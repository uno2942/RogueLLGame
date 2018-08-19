using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * /brief It is the Rat enemy class.
 */
public class Rat : Enemy
{
    
    

    /** 
     * There is a debug code.
     * incomplete:: shld be read settings file
     */
    protected override void Start()
    {
        Debug.Log("쥐 나타남");
        level = 1;
        attack = 1; //shld be decided by level and setting file
        defense = 0;
        maxhp = 3;
        hp = maxhp;
        debuffPercent = 0.0f;
        enemyAction = new EnemyAction(this);
        debuff = new Poison(2);
        player = GameObject.Find( "Player" ).GetComponent<Player>();
        base.Start();
    }
    /** 
 * There is a debug code.
 * When player clicked this gameobject, player attack to this enemy, and turn of the game flows.
 */

    /** \change enemy's Status by level and isHallucinated
     */
    public override void changeStatus(bool isHallucinated)
    {
        //read setting file and change
        if (isHallucinated == true)
        {
            attack = 2;
            defense = 0;
            debuffPercent = 0.25f;
            debuff = new Poison(3);
        }
        else
        {
            attack = 1;
            defense = 0;
            debuffPercent = 0.0f;
            debuff = new Poison(2);
        }
    }


}
