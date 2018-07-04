using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDrug : Drug {

    public override bool DrunkBy( Player player ) {
        player.AddBuff( new Poison( 30 ) );
        return true;
    }

    public override bool ThrownTo( Enemy enemy ) {
        enemy.AddBuff( new Poison( 30 ) );
        return true;
    }
}
