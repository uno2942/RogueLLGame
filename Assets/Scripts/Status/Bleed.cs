using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : Buff {

    public Bleed(int _count) : base( _count ) {
    }

    /**
     * It returns -5 for damage. In the case except attacking and moving, it need to be modified to -2.
     */
    public override int BuffWork() {
        return -5;
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
