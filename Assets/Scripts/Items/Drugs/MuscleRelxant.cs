using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * I need to count the used times of this drug.
 */
public class MuscleRelxant : Drug {

    public override bool DrunkBy( Player player ) {
        player.ChangeAttack( 1 );
        return true;
    }
}
