using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sugar : Capsule {
    public Sugar() {
        name = this.GetType().ToString();
    }
    public override bool EattenBy( Player player ) {
        player.ChangeHp( 5 );
        player.ChangeMp( 10 );
        return true;
    }
    
}
