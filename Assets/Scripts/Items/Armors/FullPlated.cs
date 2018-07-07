using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullPlated : Armor {
    public FullPlated()
    {
        deffensivepower = 20;
        rank = "legendary";
    }


    public override void Check(Player player)
    {
        player.ChangeHungry(-4);
    }
}
