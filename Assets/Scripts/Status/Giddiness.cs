﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giddiness : Buff {

    public Giddiness( int _count ) : base( _count ) {
        count = _count;
    }

    public override void BuffWorkTo( Unit unit, Unit.Action action ) {
    }

    public override int passiveBuffAtk() {
        return -1000;
    }

    public override int passiveBuffDef() {
        return 0;
    }

    public override float BuffAction( Unit.Action action ) {
        return 1f;
    }
}