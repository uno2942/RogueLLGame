using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : Weapon {

    private int count;
    public Shock()
    {
        name = this.GetType().ToString();
        count = 5;
        attackPower = 15;
        rank = "legendary";
    }

    public override void Attack(Enemy enemy)
    {
        count--;
        enemy.AddBuff( new Stunned( 5 ) );
    }

    public override bool IsDestroyed() {
        if( count == 0 )
            return true;
        return false;
    }
}
