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

    public override void Attack(Player player, Enemy enemy)
    {
        if (count = 17) { ~this(); }
        else { count++; }
    }
}
