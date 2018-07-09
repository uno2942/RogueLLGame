using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Enemy
{

    /** 
     * There is a debug code.
     * incomplete:: shld be read settings file
     */
    private void Start()
    {
        Debug.Log("개 나타남");
        level = 1;
        attack = 6; //shld be decided by level and setting file
        defense = 1;
        maxhp = 15;
        hp = maxhp;
        debuffPercent = 0.0f;
        action = new EnemyAction();
        debuff = new Bleed(3);
    }


    /** \change enemy's Status by level and isHallucinated
     */
    public override void changeStatus(bool isHallucinated)
    {
        //read setting file and change
        if (isHallucinated == true)
        {
            attack = 8;
            defense = 1;
            debuffPercent = 0.25f;
            debuff = new Bleed(5);
        }
        else
        {
            attack = 1;
            defense = 0;
            debuffPercent = 0.0f;
            debuff = new Bleed(3);
        }
    }


}