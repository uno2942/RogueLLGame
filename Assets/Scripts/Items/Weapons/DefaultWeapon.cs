using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeapon : Weapon {
    public DefaultWeapon() {
        name = this.GetType().ToString();
        attackPower = 3;
        rank = "common";
    }
}
