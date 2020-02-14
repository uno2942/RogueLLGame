using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mess : Weapon {
    public Mess()
    {
        name = this.GetType().ToString();
        attackPowerMin = 7;
        rank = ItemManager.Rank.Common;
        SetMaxAtkbyRank( rank );
    }
}
