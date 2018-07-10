using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingPill : Capsule {
    public SleepingPill() {
        name = this.GetType().ToString();
    }
    public override bool EattenBy( Player player ) {
        player.AddBuff( new Sleep( 10 ) );
        return true;
    }
}
