using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedDoctorCloth: Armor { 
    public DamagedDoctorCloth()
    {
        name = this.GetType().ToString();
        defensivePower = 5;
        rank = "common";
    }
}
