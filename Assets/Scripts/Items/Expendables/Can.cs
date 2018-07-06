using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : Else {

    public override bool UsedBy(Player player) {
        player.ChangeHungry( -50 );
        player.ChangeHp( 10 );
        return true;
    }
    //set은 private
}
