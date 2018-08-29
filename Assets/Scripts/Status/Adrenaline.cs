using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adrenaline : Buff {

    public Adrenaline(int _count) : base(_count) {

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
    /**
     * This function increases attack damage and hit damage by 1.5 times.
     */
    public override float BuffAction( Unit.Action action ) {
        return 1.5f;
    }
}
