using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * /brief It is the Rat enemy class.
 */
public class Rat : Enemy
{
    
    private int[] hpDB;
    private int[] atkDB;
    private int[] defDB;
    private float[] debuffDB;
    private float[] hDebuffDB;
    /** 
     * There is a debug code.
     * incomplete:: shld be read settings file
     */
    protected override void Start()
    {
        base.Start();
        Debug.Log("쥐 나타남");
        hpDB = new int[ 6 ] { 7, 9, 18, 22, 40, 47 };
        atkDB = new int[ 6 ] { 1, 1, 1, 1, 3, 3 };
        defDB = new int[ 6 ] { 0, 0, 0, 0, 1, 1 };
        debuffDB = new float[ 6 ] { 0.0f, 0.0f, 0.1f, 0.1f, 0.4f, 0.4f};
        hDebuffDB = new float[ 6 ] { 0.25f, 0.25f, 0.45f, 0.45f, 0.9f, 0.9f };

        level = boardManager.WhichFloor;
        attack = atkDB[level]; //shld be decided by level and setting file
        defense = defDB[level];
        maxhp = hpDB[level];
        hp = maxhp;
        debuffPercent = debuffDB[ level ];
        enemyAction = new EnemyAction(this);
        debuff = new Poison(2);
        player = GameObject.Find( "Player" ).GetComponent<Player>();
    }
    /** 
 * There is a debug code.
 * When player clicked this gameobject, player attack to this enemy, and turn of the game flows.
 */

    /** \change enemy's Status by level and isHallucinated
     */
    public override void ChangeStatus(bool isHallucinated)
    {
        base.ChangeStatus( isHallucinated );
        if(isHallucinated) {
            debuffPercent = debuffDB[ level ];
        } else {
            debuffPercent = hDebuffDB[ level ];
        }
    }


}
