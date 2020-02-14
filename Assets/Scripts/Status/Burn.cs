using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Buff {

    public Burn(int _count) : base( _count) { //count is not deinfed.
    
        count--;}

    public override void BuffWorkTo( Unit unit, Unit.Action action ) {
        unit.ChangeHp( -3 );
        count--;
    }

    public override int IntermdeiateBuffAtk() { return -2; }

    public override int IntermdeiateBuffDef() { return -2; }

    public override float BuffAction( Unit.Action action ) { return 1f; }
}
