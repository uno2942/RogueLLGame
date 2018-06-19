using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidFlameMedicine : Flask {

    public override void DrunkBy( Player player ) {
        player.AddStatus( StatusCheck.StatusEnum.Burn );
    }

    public override void ThrownTo( Enemy enemy ) {
        enemy.AddStatus( StatusCheck.StatusEnum.Burn );
    }
}
