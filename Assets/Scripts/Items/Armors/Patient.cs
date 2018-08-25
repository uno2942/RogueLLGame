using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : Armor {

    public Patient()
    {
        name = this.GetType().ToString();
        defensivePowerMin = 2;
        rank = ItemManager.Rank.Common;
        SetMaxDefbyRank( rank );
    }

}
