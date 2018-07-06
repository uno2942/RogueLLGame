using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelievingMedicine : Capsule {

    public override void EattenBy( Player player ) {
        player.AddStatus( StatusCheck.StatusEnum.Relieve );
    }
}
