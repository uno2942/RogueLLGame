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
        count--;
    }

    public override bool IsDestroyed() {
        Debug.Log( "count is " );
        Debug.Log( count );
        if( count == 0 )
            return true;
        return base.IsDestroyed();
    }
}
