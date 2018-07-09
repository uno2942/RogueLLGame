﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon {
    public Hammer()
    {
        attackPower = 10;
        rank = "rare";
    }

    public override void Attack(Player player, Enemy enemy)
    {
        player.ChangeHungry(-1);
    }
}