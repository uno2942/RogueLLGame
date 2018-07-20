using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Full : Buff {

    public Full( int _count ): base(_count) {
        count = _count;
    }

    public override void BuffWorkTo( Unit unit, Unit.Action action ) {
        Player player = unit as Player;
        player.ChangeHp( 2 );
        player.
    }
   
    public override int passiveBuffAtk() {

    }
    
    public override int passiveBuffDef() {

    }
    
    public override float BuffAction( Unit.Action action ) {

    }
}
