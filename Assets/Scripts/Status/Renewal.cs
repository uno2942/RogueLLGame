using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renewal : Buff {

    public Renewal(int _count): base(_count) {

    }
    public override void BuffWorkTo( Unit unit, Unit.Action action ) {
        if(unit is Player)
            unit.ChangeHp( 5 );
        count--;
    }

    public override int IntermdeiateBuffAtk() {
        return 0;
    }
    public override int IntermdeiateBuffDef() {
        return 0;
    }
    public override float BuffAction( Unit.Action action ) {
        return 1f;
    }
}
