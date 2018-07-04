using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * @todo We need to implement the code that make Medicine combining two DiscardedMedicine.
 */
public class DiscardedMedicine : Else {

    public override bool UsedBy( Player player ) {
        player.ChangeMp( -10 );
        return true;
    }
}
