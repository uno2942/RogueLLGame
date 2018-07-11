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
            defensivePower = 16;
        }
        else
            defensivePower = 2;
        rank = "legendary";
    }

    public override void Check(Player player)
    {
        if( Equals( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hallucinated ) ) ), null ) ){
            defensivePower = 16;
        }
        else
            defensivePower = 2;
    }
}
