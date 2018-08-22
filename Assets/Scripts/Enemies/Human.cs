using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Enemy
{
    private int[] hpDB;
    private int[] atkDB;
    private int[] defDB;
    /** 
     * There is a debug code.
     * incomplete:: shld be read settings file
     */
    protected override void Start()
    {
        base.Start();
        Debug.Log( "사람 나타남" );
        hpDB = new int[ 6 ] { 50, 60, 100, 115, 170, 195 };
        atkDB = new int[ 6 ] { 2, 2, 4, 5, 7, 9 };
        defDB = new int[ 6 ] { 1, 1, 3, 4, 6, 7 };

        level = boardManager.WhichFloor;
        attack = atkDB[ level ]; //shld be decided by level and setting file
        defense = defDB[ level ];
        maxhp = hpDB[ level ];
        hp = maxhp;
        debuffPercent = 0.0f;
        enemyAction = new EnemyAction( this );
        debuff = null;
        player = GameObject.Find( "Player" ).GetComponent<Player>();
    }

    public override void ChangeStatus( bool isHallucinated ) {
        base.ChangeStatus( isHallucinated );
    }

    /** \ incomplete: shld access at room
     * 
     */
}