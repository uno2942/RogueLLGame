using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodJacket : Armor
{
    public BloodJacket()
    {
        Player player = GameObject.Find( "Player" ).GetComponent<Player>();
        name = this.GetType().ToString();
        if( Equals( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hallucinated ) ) ), null ) ){
            defensivePowerMin = 9;
        }
        else
            defensivePowerMin = 1;
        rank = ItemManager.Rank.Common;
        SetMaxDefbyRank( rank );
    }

    public override void Check(Player player)
    {
        if( Equals( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hallucinated ) ) ), null ) ){
            defensivePowerMin = 9;
        }
        else
            defensivePowerMin = 1;
        SetMaxDefbyRank( rank );
    }
}
