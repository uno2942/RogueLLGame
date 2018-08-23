using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectorWeapon : Weapon { 
    public InjectorWeapon()
    {
        name = this.GetType().ToString();
        attackPower = 2;
        rank = "rare";
    }

    public override void Attack(Enemy enemy)
    {
            enemy.AddBuff(new Poison(5));
    }
}
