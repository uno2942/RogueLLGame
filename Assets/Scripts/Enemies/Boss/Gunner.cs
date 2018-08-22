using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : Boss {


    public int atkBuffTurn;
    public bool atkBuffOn;

    private void Start()
    {
        Debug.Log("거너 등장");
        level = 1;
        attack = 4; //shld be decided by level and setting file
        defense = 4;
        maxhp = 160;
        hp = maxhp;
        debuffPercent = 0.0f;
        enemyAction = new GunnerAction( this );
        debuff = new Stunned(1);
        atkBuffTurn = 0;
        atkBuffOn = false;
    }


    /** \change enemy's Status by level and isHallucinated
     */
    public override void changeStatus(bool isHallucinated)
    {
        //read setting file and change
        if (isHallucinated == true)
        {
            attack = 6;
            defense = 6;

        }
        else
        {
            attack = 4;
            defense = 4;

        }
    }

    /** \ incomplete: shld access at room
     * 
     */

    public override void dropItem()
    {
        //drop AutoGun
    }
}
