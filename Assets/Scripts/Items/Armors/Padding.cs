using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padding : Armor
{
    int count;
    public Padding()
    {
        name = this.GetType().ToString();
        defensivePowerMin = 6;
        rank = ItemManager.Rank.Common;
        SetMaxDefbyRank( rank );
        count = 20;
    }
    
    void onAttack() {
        count--;
    }

    public override bool IsDestroyed() {
        if( count == 0 )
            return true;
        return false;
    }
}
