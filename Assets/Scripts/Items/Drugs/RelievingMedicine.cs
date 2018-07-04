using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelievingMedicine : Drug {

    public override void DrunkBy( Player player ) {
        player.AddStatus( StatusCheck.StatusEnum.Relieve );
    }
}
