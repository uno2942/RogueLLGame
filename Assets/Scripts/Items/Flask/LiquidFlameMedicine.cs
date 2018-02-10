using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidFlameMedicine : Flask {

    public override void Drink( Player player ) {
        player.AddStatus( StatusCheck.StatusEnum.Burn );
    }

    public override void ThrownTo( Enemy enemy ) {
        enemy.AddStatus( StatusCheck.StatusEnum.Burn );
    }
    // Use this for initialization
    void Start () {
        name = "LiquidFlameMedicine";
    }
}
