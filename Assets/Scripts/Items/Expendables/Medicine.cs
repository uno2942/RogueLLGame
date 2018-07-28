using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : Expendable {
    public Medicine() {
        name = this.GetType().ToString();
    }
    public override bool UsedBy( Player player ) {
        player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Poison ) ) ) );
        return true;
    }
}
