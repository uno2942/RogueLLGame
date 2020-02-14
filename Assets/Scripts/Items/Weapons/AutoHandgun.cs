using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHandgun : Weapon{

    private int count;
    public AutoHandgun()
    {
        name = this.GetType().ToString();
        count = 17;
        attackPowerMin = 16;
        attackPowerMin = 65;
        rank = ItemManager.Rank.Legendary;
    }

    public override void GiveImpactToEnemy( Enemy enemy)
    {
        count--;
    }

    public override void SetMaxAtkbyRank( ItemManager.Rank rank ) {
        
    }


    public override bool IsDestroyed() {
        Debug.Log( "count is " );
        Debug.Log( count );
        if( count == 0 )
            return true;
        return base.IsDestroyed();
    }
}
