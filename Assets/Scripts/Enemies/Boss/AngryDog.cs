using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryDog : Boss {
    
    protected override void Start()
    {
        base.Start();
        Debug.Log("분노의 맹견 등장");
        level = 1;
        defaultA = attack = 4; //shld be decided by level and setting file
        defaultD = defense = 1;
        maxhp = 550;
        hp = maxhp;
        debuffPercent = 0.0f;
        enemyAction = new AngryDogAction(this);
        debuff = null;
        delA = 3;
        delD = 1;
    }


    /** \change enemy's Status by level and isHallucinated
     */

}
