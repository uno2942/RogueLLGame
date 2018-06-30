using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ItemAction {

    protected int attackPower;

    public int AttackPower
    {
        get
        {
            return attackPower;
        }
    }

    public virtual void Check() {

    }
    public virtual void Attack(Enemy enemy) {

    }
    //set은 private
}
