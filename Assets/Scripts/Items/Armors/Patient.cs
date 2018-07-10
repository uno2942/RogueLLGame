using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : Armor {

    public Patient()
    {
        name = this.GetType().ToString();
        deffensivepower = 3;
        rank = "common";
    }

}
