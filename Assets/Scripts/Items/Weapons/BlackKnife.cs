using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnife : Weapon {
    public BlackKnife()
    {
        name = this.GetType().ToString();
        attackPower = 2;
        rank = "rare";
    }

    public override void Equip(Player player)
    {
        if (Equals(player.Bufflist.Find(x => GetType().Equals(typeof(Hallucinated))), null))
        {
            player.AddBuff(new Hallucinated(-1));
        }
    }
    public override void Check( Player player ) {
        if( player.Mp > 59 ) { player.ChangeMp( -( player.Mp - 59 ) ); }
    }
}