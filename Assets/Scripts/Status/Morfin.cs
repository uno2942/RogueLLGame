﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morfin : Buff {

    public Morfin(int _count) : base(_count) {

    }

    public override void BuffWorkTo( Unit unit, Unit.Action action ) {
        count--;
    }
    public override int IntermdeiateBuffAtk() {
        return -7;
    }
    public override int IntermdeiateBuffDef() {
        return 0;
    }
    public override float BuffAction( Unit.Action action ) {
        return 0.5f;
    }
}
