using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : Armor {

    public Patient()
    {
        name = this.GetType().ToString();
        defensivePower = 3;
        rank = "common";
    }

}
