using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : Weapon { 
    public Lighter()
    {
        name = this.GetType().ToString();
        attackPower = 2;
        rank = "rare";
    }

    public override void Attack(Enemy enemy)
    {
            enemy.AddBuff(new Burn(5));
    }
}
