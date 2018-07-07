using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {

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
    public virtual void Attack(Enemy enemy,Player player) {

    }
    //set은 private
}
