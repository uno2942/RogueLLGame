using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidFlameMedicine : Drug {
    /**
     * @todo yes.
     */
    public override bool DrunkBy( Player player ) {
        player.AddBuff( new Burn( 10 ) );
        //Find enemy in the room
        for( int i = 0; i < enemynum; i++ )
            enemy[ i ].AddBuff( new Burn( 10 ) );
        return true;
    }

    public override bool ThrownTo( Enemy enemy ) {
        enemy.AddBuff( new Burn(10));
        return true;
    }
}
