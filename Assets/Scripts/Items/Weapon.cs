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
    //set은 private
}
