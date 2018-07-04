using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaffeinDrug : Drug {

    public override bool DrunkBy( Player player ) {
        player.ChangeMp( 25 );
        player.AddBuff( new Caffeine( 30 ) );
        return true;
    }
}
