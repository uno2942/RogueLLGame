using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starve : Status {
    public override void DoAction()
    {
        if ( !IsActive ) return;
        unit.ChangeHp (-2);
    }
}
