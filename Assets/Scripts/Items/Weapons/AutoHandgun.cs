using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHandgun : Weapon{

    private int count;
    public AutoHandgun()
    {
        name = this.GetType().ToString();

        count = 17;
        attackPower = 25;
        rank = "common";
    }

    public override void Attack(Enemy enemy)
    {
        if (count == 17) {
            //안대요..
        }
        else { count++; }
    }
}
