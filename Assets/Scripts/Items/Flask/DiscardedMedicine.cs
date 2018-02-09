using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardedMedicine : Flask {

    public override void Drink( Player player ) {
        player.ChangeMp( -5 );
    }

    // Use this for initialization
    void Start () {
        name = "DiscardedMedicine";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
