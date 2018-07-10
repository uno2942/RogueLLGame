using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuckle : Weapon {
    public Nuckle() {
        name = this.GetType().ToString();
        attackPower = 3;
        rank = "common";
    }
}
