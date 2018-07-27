using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tshirts : Armor {
    public Tshirts()
    {
        name = this.GetType().ToString();
        defensivePower = 2;
        rank = "common";
    }
}
