using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalyzingMedicine : Capsule {
    public ParalyzingMedicine() {
        name = this.GetType().ToString();
    }
    public override bool EattenBy( Player player ) {
    }
    public override bool ThrownTo( Enemy enemy ) {
        enemy.AddStatus( StatusCheck.StatusEnum.Burn ); //paralyzed
    }
}
