using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : Weapon {

    private int count;
    public Shock()
    {
        count = 0;
        attackPower = 15;
        rank = "legendary";
    }

    public ~Shock()
    { }

    public override void Attack(Player player, Enemy enemy)
    {
        if (count = 5) { ~this(); }
        else
        {
            enemy.AddBuff(new Paralyzed(5));
            count++; }
    }
}
