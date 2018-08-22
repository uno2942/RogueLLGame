using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryDog : Boss {

    protected override void Start()
    {
        base.Start();
        Debug.Log("분노의 맹견 등장");
        level = 1;
        attack = 6; //shld be decided by level and setting file
        defense = 2;
        maxhp = 230;
        hp = maxhp;
        debuffPercent = 0.0f;
        enemyAction = new AngryDogAction(this);
        debuff = null;
    }


    /** \change enemy's Status by level and isHallucinated
     */
    public override void ChangeStatus( bool isHallucinated ) {
        base.ChangeStatus( isHallucinated );
    }

}
