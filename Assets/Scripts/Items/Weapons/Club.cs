using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : Weapon
{
    public Club()
    {
        name = this.GetType().ToString();
        attackPowerMin = 10;
        rank = ItemManager.Rank.Common;
        SetMaxAtkbyRank(rank);
    }

    public override void Attack( Enemy enemy ) {
        float f = Random.Range( 0, 100 );
        switch( rank ) {
        case ItemManager.Rank.Common:
            if( f < 25 )
                attackPowerMin--;
            break;
        case ItemManager.Rank.Rare:
            if( f < 20 )
                attackPowerMin--;
            break;
        case ItemManager.Rank.Legendary:
            if( f < 15 )
                attackPowerMin--;
            break;
        default: return;
        }
    }
}
