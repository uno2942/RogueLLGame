using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon {
    public Hammer()
    {
        name = this.GetType().ToString();
        attackPower = 8;
        rank = "rare";
    }

    public override void Attack( Enemy enemy)
    {
        Player player = GameObject.Find( "Player" ).GetComponent<Player>();
        player.ChangeHungry(-1);
    }
}
