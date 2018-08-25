using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDoctorCloth : Armor
{
    public CleanDoctorCloth()
    {
        name = this.GetType().ToString();
        defensivePowerMin = 5;
        rank = ItemManager.Rank.Rare;
        SetMaxDefbyRank( rank );
    }
}
