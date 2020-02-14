using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relieved : Buff {

    public Relieved( int _count ) : base( _count ) {//턴 수가 안 정해져 있음.

    }
    /**
 * @todo I need to change enemy's attack part.
 */
    public override void BuffWorkTo( Unit unit, Unit.Action action ) {
        count--;
    }
    public override int IntermdeiateBuffAtk() {
        return -3;
    }

    public override int IntermdeiateBuffDef() {
        return 0;
    }

    public override float BuffAction( Unit.Action action ) {
        return 1f;
    }
}

