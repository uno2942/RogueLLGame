using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeapon : Weapon {
    public DefaultWeapon() {
        name = this.GetType().ToString();
        attackPowerMin = 40;
        attackPowerMax = 70;
        rank = ItemManager.Rank.Common;
    }
    public override void SetMaxAtkbyRank( ItemManager.Rank rank ) {

    }
}
