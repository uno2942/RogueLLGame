using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : Weapon { 
    public Lighter()
    {
        name = this.GetType().ToString();
        attackPowerMin = 3;
        rank = ItemManager.Rank.Common;
        SetMaxAtkbyRank( rank );
    }

    public override void GiveImpactToEnemy( Enemy enemy)
    {
        switch( rank ) {
        case ItemManager.Rank.Common: enemy.AddBuff( new Burn( 3 ) ); break;
        case ItemManager.Rank.Rare: enemy.AddBuff( new Burn( 4 ) ); break;
        case ItemManager.Rank.Legendary: enemy.AddBuff( new Burn( 5 ) ); break;
        default: break;
        }
    }
}
