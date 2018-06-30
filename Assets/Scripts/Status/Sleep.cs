using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : Buff {

    public Sleep(int _count) : base( _count ) {

    }

    /**
     * Sleeping buff increases HP by 3 and MP by 12, but the function should return only one parameter(in lower version C#), so I'll only return HP increase.
     */
    public override int BuffWork() {
        return 3;
    }
    public override int passiveBuffAtk() {
        return 0;
    }
    public override int passiveBuffDef() {
        return 0;
    }
    public override float passiveBuffFinal() {
        return 4f;
    }
}
