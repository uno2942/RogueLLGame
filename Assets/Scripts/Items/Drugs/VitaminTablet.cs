using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitaminTablet : Drug {

    public override bool DrunkBy( Player player ) {
        player.ChangeHp( 15 );
        player.ChangeMp( 15 );
        return true;
    }

    public override bool ThrownTo( Enemy enemy ) {
        enemy.AddBuff( new VitaminThrown( 30 ) );
        return true;
    }
}
