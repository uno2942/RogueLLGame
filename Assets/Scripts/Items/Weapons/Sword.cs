using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon {
    public Sword() {
        name = this.GetType().ToString();
        attackPower = 10;
    }
}
