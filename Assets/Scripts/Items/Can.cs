using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : Item {

    public void EattenBy( Player player) {
        player.ChangeHungry( -20 );
        Random.InitState( (int) System.DateTime.Now.Ticks );
        int isRotten = Random.Range( 0, 2 );
        if( isRotten == 1 )
            player.AddStatus( StatusCheck.StatusEnum.Poison );
    }
    //set은 private


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
