using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardedMedicine : Flask {

    public override void DrunkBy( Player player ) {
        player.ChangeMp( -5 );
    }
}
