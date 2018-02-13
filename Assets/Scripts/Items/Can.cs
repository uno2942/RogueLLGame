using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : ItemAction {

    public void EattenBy(Player player) {
        player.ChangeHungry( -20 );
        Random.InitState( (int) System.DateTime.Now.Ticks );
        int isRotten = Random.Range( 0, 2 );
        if( isRotten == 1 )
            player.AddStatus( StatusCheck.StatusEnum.Poison );
    }
    //set은 private
}
