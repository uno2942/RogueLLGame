using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : Weapon {

    private int count;
    public Shock()
    {
        name = this.GetType().ToString();
        count = 5;
        attackPowerMin = 10;
        attackPowerMax = 41;
        rank = ItemManager.Rank.Legendary;
    }
    
    public override void GiveImpactToEnemy( Enemy enemy ) {
        count--;
        enemy.AddBuff( new Stunned( 5 ) );
    }

    public override bool IsDestroyed() {
        if( count == 0 )
            return true;
        return false;
    }
}
