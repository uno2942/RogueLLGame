using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalDirector : Enemy {

    private void Start()
    {
        Debug.Log("최종보스 정신병원 원장 등장");
        level = 1;
        attack = 10; //shld be decided by level and setting file
        defense = 10;
        maxhp = 160;
        hp = maxhp;
        debuffPercent = 0.0f;
        action = new HospitalDirectorAction( this );
        debuff = null;
    }


    /** \change enemy's Status by level and isHallucinated
     */
    public override void changeStatus(bool isHallucinated)
    {
        //read setting file and change
        if (isHallucinated == true)
        {
            attack = 18;
            defense = 18;

        }
        else
        {
            attack = 10;
            defense = 10;
        }
    }


    /** \this mob drops CureAll
     */
    public override void dropItem()
    {
        //add CureAll on Room
    }
}
