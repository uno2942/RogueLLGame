using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnife : Weapon {
    public BlackKnife()
    {
        attackPower = 2;
        rank = "rare";
    }

    public override void Check(Player player)
    {
        if (Equals(player.Bufflist.Find(x => GetType().Equals(typeof(Hallucinated))), null))
        {
            player.AddBuff(new Hallucinated(-1));
        }
        if (player.mp > 59) { player.Changemp(-(player.mp - 59)); }
    }
}

