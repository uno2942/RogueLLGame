using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : Weapon
{
    public Club()
    {
        name = this.GetType().ToString();
        attackPower = 10;
        rank = "common";
    }

    public override void Attack( Enemy enemy ) {
        float f = Random.Range( 0, 100 );
        switch( rank ) {
        case "common":
            if( f < 25 )
                attackPower--;
            break;
        case "rare":
            if( f < 20 )
                attackPower--;
            break;
        case "legendary":
            if( f < 15 )
                attackPower--;
            break;
        default: return;
        }
    }
}
