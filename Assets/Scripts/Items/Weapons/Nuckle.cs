using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuckle : Weapon {
    public Nuckle() {
        name = this.GetType().ToString();
        attackPowerMin = 4;
        rank = ItemManager.Rank.Common;
        SetMaxAtkbyRank( rank );
    }

    public override void Attack( Enemy enemy ) {
        
    }
}
