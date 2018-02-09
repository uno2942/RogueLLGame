using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidFlameMedicine : Flask {

    public override void DoAction( Player player ) {
        player.AddStatus( StatusCheck.StatusEnum.Burn );
    }

    // Use this for initialization
    void Start () {
        name = "LiquidFlameMedicine";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
