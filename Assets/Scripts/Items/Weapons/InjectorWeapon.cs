using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectorWeapon : Weapon { 
    public InjectorWeapon()
    {
        name = GetType().ToString();
        attackPowerMin = 5;
        rank = ItemManager.Rank.Common;
        SetMaxAtkbyRank( rank );
    }

    public override void Attack( Enemy enemy ) {
        switch( rank ) {
        case ItemManager.Rank.Common: enemy.AddBuff( new Poison( 4 ) ); break;
        case ItemManager.Rank.Rare: enemy.AddBuff( new Poison( 5 ) ); break;
        case ItemManager.Rank.Legendary: enemy.AddBuff( new Poison( 6 ) ); break;
        default: break;
        }
    }
}
