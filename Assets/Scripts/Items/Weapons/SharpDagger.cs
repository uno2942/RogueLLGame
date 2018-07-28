using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpDagger : Weapon {
    public SharpDagger()
    {
        name = this.GetType().ToString();
        attackPower = 11;
        rank = "rare";
    }
}
