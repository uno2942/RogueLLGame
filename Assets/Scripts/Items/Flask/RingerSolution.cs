using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingerSolution : Flask {

    public override void DrunkBy( Player player ) {
        player.ChangeHp( 50 );
        player.ChangeHungry( -40 );
    }
}
