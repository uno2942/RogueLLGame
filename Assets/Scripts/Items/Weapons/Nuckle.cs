using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuckle : Weapon {
    public Nuckle() {
        name = this.GetType().ToString();
        attackPower = 4;
        rank = "common";
    }

    public override void Attack( Enemy enemy ) {
        
    }
}
