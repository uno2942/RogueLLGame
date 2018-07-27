﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equip {

    protected int attackPower;
    public int AttackPower
    {
        get
        {
            return attackPower;
        }
    }

    public virtual void Check(Player player) {

    }
    public virtual void Attack(Enemy enemy ) {

    }
    //set은 private
}
