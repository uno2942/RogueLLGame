using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeapon : Weapon {
    public DefaultWeapon() {
        name = this.GetType().ToString();
        attackPowerMin = 2;
        attackPowerMax = 7;
        rank = ItemManager.Rank.Common;
    }
    public override void SetMaxAtkbyRank( ItemManager.Rank rank ) {

    }
}
