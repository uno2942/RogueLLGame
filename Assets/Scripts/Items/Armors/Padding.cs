using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padding : Armor
{
    public Padding()
    {
        name = this.GetType().ToString();
        defensivePower = 9;
        rank = "rare";
    }

}
