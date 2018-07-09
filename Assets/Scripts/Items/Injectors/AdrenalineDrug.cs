﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrenalineCapsule : Injector {

    public override bool InjectedBy( Player player ) {
        if( Equals( player.Bufflist.Find( x => x.GetType().Equals( typeof( Morfin ) ) ), null ) ) {
            player.ChangeMp( -10 );
            player.AddBuff( new Adrenaline( 10 ) );
            return true;
        }
        return false;
    }
}