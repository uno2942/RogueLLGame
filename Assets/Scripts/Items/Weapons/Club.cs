using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : Weapon
{
    public Club()
    {
        name = this.GetType().ToString();
        attackPowerMin = 10;
        rank = ItemManager.Rank.Common;
        SetMaxAtkbyRank(rank);
    }
    public void DecreaseAttackMin() {
        attackPowerMin --;
    }
}
