using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalyzingMedicine : Flask {

    public override void DrunkBy( Player player ) {
    }
    public override void ThrownTo( Enemy enemy ) {
        enemy.AddStatus( StatusCheck.StatusEnum.Burn ); //paralyzed
    }
    // Use this for initialization
    void Start () {
        name = "ParalyzingMedicine";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
