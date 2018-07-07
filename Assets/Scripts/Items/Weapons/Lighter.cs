using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : Weapon { 
    public Lighter()
    {
        attackPower = 2;
        rank = "rare";
    }

    public override void Attack(Player player, Enemy enemy)
    {
            enemy.AddBuff(new Burn(5));
    }
}
