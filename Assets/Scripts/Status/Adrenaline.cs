using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adrenaline : Buff {

    public Adrenaline(int _count) : base(_count) {

    }

    public override void BuffWorkTo( Player player ) {

        count--;
    }
    public override int passiveBuffAtk() {
        return -7;
    }
    public override int passiveBuffDef() {
        return 0;
    }
    /**
     * This function increases attack damage and hit damage by 1.5 times.
     */
    public override float passiveBuffFinal() {
        return 1.5f;
    }
}
