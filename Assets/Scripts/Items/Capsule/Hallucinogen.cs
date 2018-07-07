using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallucinogen : Capsule {

    public override bool EattenBy( Player player ) {
        if( Equals( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hallucinated ) ) ), null ) ) {
            player.AddBuff( new Hallucinated( -1 ) );
        } else
            player.ChangeMp( -10 );
        return true;
    }
    public override bool ThrownTo( Enemy enemy ) {
        enemy.AddBuff( new HitByHallucinogen( 3 ) );
        return true;
    }
}
