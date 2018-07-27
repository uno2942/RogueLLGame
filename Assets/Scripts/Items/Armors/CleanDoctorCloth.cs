using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDoctorCloth : Armor
{
    public CleanDoctorCloth()
    {
        name = this.GetType().ToString();
        defensivePower = 7;
        rank = "rare";
    }
}
