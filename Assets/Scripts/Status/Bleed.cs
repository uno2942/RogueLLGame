using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : Buff {

    public Bleed(int _count) : base( _count ) {
    }

    /**
     * @todo 플레이어가 이동/공격 중인지 확인해주어야 한다.
     */
    public override void BuffWorkTo( Player player ) {
        player.ChangeHp( -5 );
        count--;
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
