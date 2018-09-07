using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon {
    public Hammer()
    {
        name = this.GetType().ToString();
        attackPowerMin = 8;
        rank = ItemManager.Rank.Common;
        SetMaxAtkbyRank( rank );
    }
    
    public override void GiveImpactToPlayer( Player player ) {
        player.ChangeHungry( 1 );
    }
}
