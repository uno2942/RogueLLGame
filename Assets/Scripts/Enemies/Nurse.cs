﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : Enemy {

    private void Start()
    {
        Debug.Log("간호사 등장");
        level = 1;
        attack = 11; //shld be decided by level and setting file
        defense = 2;
        maxhp = 230;
        hp = maxhp;
        debuffPercent = 0.0f;
        action = new NurseAction();
        debuff = null;
    }


    /** \change enemy's Status by level and isHallucinated
     */
    public override void changeStatus(bool isHallucinated)
    {
        //read setting file and change
        if (isHallucinated == true)
        {
            attack = 16;
            defense = 2;

        }
        else
        {
            attack = 11;
            defense = 2;
        }
    }

    

}