﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : Buff {

    public Hunger() : base( -1 ) {

    }

    public override void BuffWorkTo( Unit unit, Unit.Action action ) {
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
