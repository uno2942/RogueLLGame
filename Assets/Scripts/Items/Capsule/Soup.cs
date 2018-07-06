using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soup : Capsule {

    public override bool EattenBy( Player player ) {
        player.ChangeHp( 30 );
        player.ChangeMp( 20 );
        player.ChangeHungry( -50 );
        return true;
    }

    public override bool ThrownTo( Enemy enemy ) {
        return true;
    }
}
