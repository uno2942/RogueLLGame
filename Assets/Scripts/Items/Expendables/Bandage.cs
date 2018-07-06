using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandage : Else {
    public override bool UsedBy( Player player ) {
        player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Bleed ) ) ) );
        return true;
    }
}
