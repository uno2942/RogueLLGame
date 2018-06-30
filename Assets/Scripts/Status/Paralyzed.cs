using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralyzed : Buff {

    Paralyzed( int _count ) : base( _count ) {

    }

    public override int BuffWork() {
        return -3;
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
