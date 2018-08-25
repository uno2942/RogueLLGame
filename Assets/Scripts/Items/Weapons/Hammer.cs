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

    public override void Attack( Enemy enemy)
    {
        Player player = GameObject.Find( "Player" ).GetComponent<Player>();
        player.ChangeHungry(-1);
    }
}
