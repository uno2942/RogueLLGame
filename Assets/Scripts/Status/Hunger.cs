using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : Buff {

    public Hunger() : base( -1 ) {

    }

    public override int BuffWork() {
        return 0;
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
