using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renewal : Buff {

    public Renewal(int _count): base(_count) {

    }
    public override void BuffWorkTo( Unit unit ) {
        if(unit is Player)
            unit.ChangeHp( 5 );
        count--;
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
