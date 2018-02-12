using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetoxificatingMedicine : Flask {

    public override void DrunkBy( Player player ) {
        player.DeleteStatus( StatusCheck.StatusEnum.Poison );
    }
    // Use this for initialization
    void Start () {
        name = "DetoxificatingMedicine";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
