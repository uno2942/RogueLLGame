using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ethanol : Flask {

    public override void DrunkBy( Player player ) {
        player.ChangeHp( -10 );
        player.ChangeMp( 15 );
    }
    
}
