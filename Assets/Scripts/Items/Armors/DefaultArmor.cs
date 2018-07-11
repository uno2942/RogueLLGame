using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultArmor : Armor {
    public DefaultArmor() {
        name = this.GetType().ToString();
        defensivePower = 0 ;
        rank = "common";
    }
}
