using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeningMedicine : Flask {

    public override void Drink( Player player ) {

        player.AddStatus( StatusCheck.StatusEnum.Awaken );
    }

    // Use this for initialization
    void Start () {
        name = "AwakeningMedicine";

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
