using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureAll : Capsule {

    public override bool EattenBy( Player player ) {
        if( player.Hp != player.MaxHp )
            player.ChangeHp( player.MaxHp );
        else
            player.ChangeMaxHp( 15 );
        player.ChangeMp( (int) ( ( player.MaxMp - player.Mp ) * 0.5 ) );

        player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hallucinated ) ) ) );
        player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Burn ) ) ) );
        player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Poison ) ) ) );
        player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Bleed ) ) ) );
        return true;
    }
}
