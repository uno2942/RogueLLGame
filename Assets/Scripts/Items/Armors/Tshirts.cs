using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tshirts : Armor {
    public Tshirts()
    {
        name = this.GetType().ToString();
        deffensivepower = 2;
        rank = "common";
    }
}
