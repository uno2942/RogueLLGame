using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : Status {
    public override void DoAction()
    {
        if ( !IsActive ) return;
        unit.ChangeHp (-5);
        RemainTurn--;
        if ( RemainTurn == 0 )
        {
            Inactivate ();
        }
    }
    public override void Activate()
    {
        IsActive = true;
        RemainTurn = 5;
    }
    public override void Inactivate()
    {
        IsActive = false;
        RemainTurn = 0;
    }
}
