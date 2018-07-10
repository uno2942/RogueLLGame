using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salt : Capsule {
    public Salt() {
        name = this.GetType().ToString();
    }
    public override bool EattenBy( Player player ) {
        if( Equals( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hallucinated ) ) ), null ) )
            player.ChangeMp( -30 );
        else
            player.ChangeMp( -60 );
        return true;
    }
}
