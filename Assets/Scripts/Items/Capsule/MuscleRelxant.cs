using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * I need to count the used times of this capsule.
 */
public class MuscleRelxant : Capsule {

    public override bool EattenBy( Player player ) {
        player.ChangeAttack( 1 );
        return true;
    }
}
