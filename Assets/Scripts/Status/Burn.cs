using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Buff {

    public Burn(int _count) : base( _count) { //count is not deinfed.
    
        count--;}

    public override void BuffWorkTo(Unit unit) {
        unit.ChangeHp( -3 );
        count--;
    }

    public override int passiveBuffAtk() { return -2; }

    public override int passiveBuffDef() { return -2; }

    public override float passiveBuffFinal() { return 1f; }
}
