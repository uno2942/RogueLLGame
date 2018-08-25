using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tshirts : Armor {
    public Tshirts()
    {
        name = this.GetType().ToString();
        defensivePowerMin = 1;
        rank = ItemManager.Rank.Common;
        SetMaxDefbyRank( rank );
    }
}
