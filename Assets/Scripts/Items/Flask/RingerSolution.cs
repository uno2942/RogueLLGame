using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingerSolution : Flask {

    public override void DoAction( Player player ) {
        player.ChangeHp( 50 );
        player.ChangeHungry( -40 );
    }
    // Use this for initialization
    void Start () {
        name = "RingerSolution";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
