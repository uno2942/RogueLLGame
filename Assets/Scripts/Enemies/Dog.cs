using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Enemy
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
        Debug.Log( "개 나타남" );
        hpDB = new int[ 6 ] { 30, 35, 63, 70, 110, 125 };
        atkDB = new int[ 6 ] { 3, 3, 5, 6, 9, 11 };
        defDB = new int[ 6 ] { 1, 1, 2, 2, 3, 3 };
        debuffDB = new float[ 6 ] { 0.0f, 0.0f, 0.1f, 0.1f, 0.4f, 0.4f };
        hDebuffDB = new float[ 6 ] { 0.25f, 0.25f, 0.45f, 0.45f, 0.9f, 0.9f };

        level = boardManager.WhichFloor;
        attack = atkDB[ level ]; //shld be decided by level and setting file
        defense = defDB[ level ];
        maxhp = hpDB[ level ];
        hp = maxhp;
        debuffPercent = debuffDB[ level ];
        enemyAction = new EnemyAction( this );
        debuff = new Bleed( 3 );
        player = GameObject.Find( "Player" ).GetComponent<Player>();

    }


    /** \change enemy's Status by level and isHallucinated
     */
    public override void ChangeStatus(bool isHallucinated)
    {
        base.ChangeStatus( isHallucinated );
        if( isHallucinated ) {
            debuffPercent = debuffDB[ level ];
        } else {
            debuffPercent = hDebuffDB[ level ];
        }
    }


}