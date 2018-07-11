using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryDog : Enemy {

    private void Start()
    {
        Debug.Log("분노의 맹견 등장 등장");
        level = 1;
        attack = 6; //shld be decided by level and setting file
        defense = 2;
        maxhp = 230;
        hp = maxhp;
        debuffPercent = 0.0f;
        action = new AngryDogAction();
        debuff = null;
    }


    /** \change enemy's Status by level and isHallucinated
     */
    public override void changeStatus(bool isHallucinated)
    {
        //read setting file and change
        if (isHallucinated == true)
        {
            attack = 12;
            defense = 2;

        }
        else
        {
            attack = 6;
            defense = 2;
        }
    }
}
