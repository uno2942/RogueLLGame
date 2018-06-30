using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Buff {

    public Burn(int _count) : base( _count) { //count is not deinfed.
    }

    public override int BuffWork() {
        return -3;
    }

    public override int passiveBuffAtk() { return -2; }

    public override int passiveBuffDef() { return -2; }

    public override float passiveBuffFinal() { return 1f; }
}
