using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padding : Armor
{
    public Padding()
    {
        name = this.GetType().ToString();
        deffensivepower = 9;
        rank = "rare";
    }

}
