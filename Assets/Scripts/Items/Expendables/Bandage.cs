using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandage : Expendable {
    public Bandage() {
        name = this.GetType().ToString();
    }
    public override bool UsedBy( Player player ) {
        player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Bleed ) ) ) );
        return true;
    }
}
