using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Expendable {
    public Water() {
        name = this.GetType().ToString();
    }
    public override bool UsedBy( Player player ) {
        if( Equals( player.Bufflist.Find( x => x.GetType().Equals( typeof( Hallucinated ) ) ), null ) )
            player.ChangeMp( 10 );
        else
            player.ChangeMp( 5 );
        return true;
    }
    
    public override bool ExpandUseBy(Player player)
    {

        if (!Equals(player.Bufflist.Find(x => x.GetType().Equals(typeof(Burn))), null))
            player.DeleteBuff(player.Bufflist.Find(x => x.GetType().Equals(typeof(Burn))));
        return true;
    }

}
