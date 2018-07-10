using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedDoctorCloth: Armor { 
    public DamagedDoctorCloth()
    {
        name = this.GetType().ToString();
        deffensivepower = 5;
        rank = "common";
    }
}
