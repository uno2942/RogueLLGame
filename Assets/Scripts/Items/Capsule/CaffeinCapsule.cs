using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaffeinCapsule : Capsule {

    public override bool EattenBy( Player player ) {
        player.ChangeMp( 25 );
        player.AddBuff( new Caffeine( 30 ) );
        return true;
    }
}
