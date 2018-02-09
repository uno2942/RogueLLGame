using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ethanol : Flask {

    public override void Drink( Player player ) {
        player.ChangeHp( -10 );
        player.ChangeMp( 15 );
    }

    // Use this for initialization
    void Start () {
        name = "Ethanol";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
