using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingPill : Drug {

    public override bool DrunkBy( Player player ) {
        player.AddBuff( new Sleep( 10 ) );
        return true;
    }
}
