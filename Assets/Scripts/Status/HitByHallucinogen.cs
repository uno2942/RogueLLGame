using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByHallucinogen : Buff {

    public HitByHallucinogen( int _count ) : base( _count ) {

    }

    public override void BuffWorkTo( Player player ) {
        count--;
    }
    public override int passiveBuffAtk() {
        return -10000;
    }
    public override int passiveBuffDef() {
        return 0;
    }
    public override float passiveBuffFinal() {
        return 1f;
    }
}
