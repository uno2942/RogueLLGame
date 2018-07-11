﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : Weapon {

    private int count;
    public Shock()
    {
        name = this.GetType().ToString();
        count = 0;
        attackPower = 15;
        rank = "legendary";
    }

    public override void Attack(Enemy enemy)
    {
        if (count == 5) {
            ///안대요...
        }
        else
        {
            enemy.AddBuff(new Paralyzed(5));
            count++;
        }
    }
}
