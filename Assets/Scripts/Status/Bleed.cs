using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : Buff {

    public Bleed(int _count) : base( _count ) {
    }

    /**
     * @todo 플레이어가 이동/공격 중인지 확인해주어야 한다.
     */
    public override void BuffWorkTo( Unit unit, Unit.Action action ) {
        if( unit is Player ) {
            if( action == Unit.Action.Attack || action == Unit.Action.Move )
                unit.ChangeHp( -5 );
            else
                unit.ChangeHp( -2 );
        }
        count--;
    }   

    public override int IntermdeiateBuffAtk() {
        return 0;
    }
    public override int IntermdeiateBuffDef() {
        return 0;
    }
    public override float BuffAction( Unit.Action action ) {
        return 1f;
    }
}
