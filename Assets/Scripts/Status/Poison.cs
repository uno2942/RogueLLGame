﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Buff {

    public Poison(int _count) : base(_count) {//턴 수가 안 정해져 있음.
                                                    
    }

    public override int BuffWork() {
        return -1;
    }
    public override int passiveBuffAtk() {
        return 0;
    }

    public override int passiveBuffDef() {
        return 0;
    }

    public override float passiveBuffFinal() {
        return 1f;
    }
}
