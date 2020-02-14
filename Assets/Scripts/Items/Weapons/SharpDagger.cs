using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpDagger : Weapon {
    public SharpDagger()
    {
        name = this.GetType().ToString();
        attackPowerMin = 6;
        rank = ItemManager.Rank.Common;
        SetMaxAtkbyRank( rank );
    }
}
