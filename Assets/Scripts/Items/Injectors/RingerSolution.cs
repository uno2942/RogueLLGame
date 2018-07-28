using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingerSolution : Injector {
    public RingerSolution() {
        name = this.GetType().ToString();
    }
    public override bool InjectedBy( Player player ) {
        if( Equals( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hallucinated ) ) ), null ) )
            player.ChangeMp( 10 );
        else
            player.ChangeMp( 15 );
        player.AddBuff( new Renewal(10) );
        return true;
    }
}
