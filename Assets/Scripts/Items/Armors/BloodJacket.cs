using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodJacket : Armor
{

    public BloodJacket()
    {
        if (Equals(player.Bufflist.Find(x => x.GetType().Equals(typeof(Hallucinated)), null)))
        {
            deffensivepower = 16;
        }
        else
            deffensivepower = 2;
        rank = "legendary";
    }

    public override void Check(Player player)
    {
        if (Equals(player.Bufflist.Find(x => x.GetType().Equals(typeof(Hallucinated)), null)))
        {
            deffensivepower = 16;
        }
        else
            deffensivepower = 2;
    }
}
