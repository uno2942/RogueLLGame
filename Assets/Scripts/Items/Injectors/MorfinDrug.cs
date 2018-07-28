using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorfinDrug : Injector {
    public MorfinDrug() {
        name = this.GetType().ToString();
    }
    public override bool InjectedBy( Player player ) {
        if( Equals( player.Bufflist.Find( x => x.GetType().Equals( typeof( Adrenaline ) ) ), null ) ) {
            player.ChangeMp( 25 );
            player.AddBuff( new Morfin( 30 ) );
            return true;
        }
        return false;
    }
}
