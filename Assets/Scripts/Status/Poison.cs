using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Status {

    public override void DoAction()
    {
        if ( !IsActive ) return;
        unit.ChangeHp (-1);
        RemainTurn--;
        if ( RemainTurn == 0 )
        {
            Inactivate ();
        }
    }
    public override void Activate()
    {
        IsActive = true;
        RemainTurn = 10;
    }
    public override void Inactivate()
    {
        IsActive = false;
        RemainTurn = 0;
    }
}
