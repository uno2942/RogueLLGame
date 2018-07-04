using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalyzingMedicine : Drug {

    public override bool DrunkBy( Player player ) {
    }
    public override bool ThrownTo( Enemy enemy ) {
        enemy.AddStatus( StatusCheck.StatusEnum.Burn ); //paralyzed
    }
}
