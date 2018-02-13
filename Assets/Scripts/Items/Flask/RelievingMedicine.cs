using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelievingMedicine : Flask {

    public override void DrunkBy( Player player ) {
        player.AddStatus( StatusCheck.StatusEnum.Relieve );
    }
}
