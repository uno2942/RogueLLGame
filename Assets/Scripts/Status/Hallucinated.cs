using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallucinated : Buff {

    public Hallucinated( int _count ) : base( _count ) {

    }

    public override void BuffWorkTo( Unit unit, Unit.Action action ) {
        count--;
    }
    public override int passiveBuffAtk() {
        return 0;
    }
    public override int passiveBuffDef() {
        return 0;
    }
    public override float BuffAction( Unit.Action action ) {
        return 1f;
    }
}
