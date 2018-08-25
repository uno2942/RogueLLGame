using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedDoctorCloth: Armor { 
    public DamagedDoctorCloth()
    {
        name = this.GetType().ToString();
        defensivePowerMin = 5;
        rank = ItemManager.Rank.Rare;
        SetMaxDefbyRank( rank );
    }
}
