using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCapsule : Capsule {

    public override bool EattenBy( Player player ) {
        player.AddBuff( new Poison( 30 ) );
        return true;
    }

    public override bool ThrownTo( Enemy enemy ) {
        enemy.AddBuff( new Poison( 30 ) );
        return true;
    }
}
