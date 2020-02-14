using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullPlated : Armor {
    public FullPlated()
    {
        name = this.GetType().ToString();
        defensivePowerMin = 12;
        rank = ItemManager.Rank.Legendary;
        defensivePowerMax = 45;
        
    }

    public override void SetMaxDefbyRank( ItemManager.Rank rank ) {
        
    }

    public override void Check(Player player)
    {
        player.ChangeHungry(-4);
    }
}
