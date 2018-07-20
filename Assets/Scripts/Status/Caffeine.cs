using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caffeine : Buff {

    public Caffeine( int _count ) : base( _count ) {

    }

    public override void BuffWorkTo( Unit unit ) {
        Player player = unit as Player;
        player.ChangeMp(-1.2f);
        count--;
    }
    public override int passiveBuffAtk() {
        return 7;
    }
    public override int passiveBuffDef() {
        return 2;
    }
    public override float passiveBuffFinal() {
        return 1f;
    }
}
