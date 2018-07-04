using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sugar : Drug {

    public override bool DrunkBy( Player player ) {
        player.ChangeHp( 5 );
        player.ChangeMp( 10 );
        return true;
    }
    
    }
}
