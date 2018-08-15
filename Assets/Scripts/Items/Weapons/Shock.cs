using System.Collections;
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
        }
        else
        {
            enemy.AddBuff(new Stunned( 5));
            count++;
        }
    }
}
