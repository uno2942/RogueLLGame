﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morfin : Buff {

    public Morfin(int _count) : base(_count) {

    }

    public override void BuffWork( Player player ) {
    }
    public override int passiveBuffAtk() {
        return -7;
    }
    public override int passiveBuffDef() {
        return 0;
    }
    public override float passiveBuffFinal() {
        return 0.5f;
    }
}
