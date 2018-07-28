using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starve : Buff {

    public Starve() : base( -1 ) {  //-1 indicates infinite counts.

    }

    public override void BuffWorkTo( Unit unit, Unit.Action action ) {
        if(unit is Player)
            unit.ChangeHp(-1);
        count--;
    }

    public override int passiveBuffAtk() {
        return 0;
    }

    public override int passiveBuffDef() { return 0; }

    public override float BuffAction( Unit.Action action ) { return 1f; }
}
