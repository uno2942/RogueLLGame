using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mess : Weapon {
    public Mess()
    {
        name = this.GetType().ToString();
        attackPower = 7;
        rank = "common";
    }
}
