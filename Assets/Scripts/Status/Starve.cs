using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starve : Buff {

    public Starve() : base( -1 ) {  //-1 indicates infinite counts.

    }

    public override void BuffWork( Player player ) {
        player.ChangeHp(-1);
    }

    public override int passiveBuffAtk() {
        return 0;
    }

    public override int passiveBuffDef() { return 0; }

    public override float passiveBuffFinal() { return 1f; }
}
