using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedCrazyAction : EnemyAction {

    /** \decrease player's MP 1.2
     *  \
     */
    public BoundedCrazyAction( Enemy enemy ) : base( enemy ) {
    }

    public override void Other()
    {
        player.ChangeMp(-1.2f);

    }

    public override bool Attack() {
        BoundedCrazy b = enemyItself as BoundedCrazy;
        b.turn++;

        if( b.turn % 2 == 1 )
            return base.Attack();
        else return false;
    }
}
