using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Flask {

    public override void DoAction( Player player ) {
        player.ChangeMp( 5 );
    }
    // Use this for initialization
    void Start () {
        name = "Water";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
