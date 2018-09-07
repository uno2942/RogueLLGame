using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedCrazy : Boss {

    public int turn;
    

    protected override void Start()
    {
        base.Start();
        Debug.Log("구속된 미치광이가 나타났습니다. 마주하고 있자니 정신이 이상해지는 듯 합니다.");
        level = 0;
        defaultA = attack = 2; //shld be decided by level and setting file
        defaultD = defense = 0;
        maxhp = 180;
        hp = maxhp;
        debuffPercent = 0.0f;
        enemyAction = new BoundedCrazyAction( this );
        player = GameObject.Find( "Player" ).GetComponent<Player>();
        debuff = null;
        turn = 0;
        delA = 9;
        delD = 0;
    }

    
    /** \change enemy's Status by level and isHallucinated
     */
    
}
