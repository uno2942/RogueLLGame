using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitaminThrown : Buff {

    public VitaminThrown( int _count ) : base( _count ) {//턴 수가 안 정해져 있음.

    }
    /**
 * @todo I need to change enemy's attack part.
 */
    public override void BuffWorkTo( Unit unit, Unit.Action action ) {
        count--;
    }
    public override int passiveBuffAtk() {
        return -5;
    }

    public override int passiveBuffDef() {
        return 0;
    }

    public override float BuffAction( Unit.Action action ) {
        return 1f;
    }
}
