using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caffeine : Buff {

    Caffeine( int _count ) : base( _count ) {

    }

    public override int BuffWork() {
        return 0;
    }
    public override int passiveBuffAtk() {
        return 7;
    }
    public override int passiveBuffDef() {
        return 2;
    }
    public override float passiveBuffFinal() {
        return 1f;
    }
}
