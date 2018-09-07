using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalDirectorAction : EnemyAction {

    /** \shld check Player's action before and change MP
     *  \Maybe this work can be done in Boss Room
     */


    public HospitalDirectorAction( Enemy enemy ) : base( enemy ) {
    }

    public override void Other()
    {
    }

    /** \override to limit max damage
     */
    public override bool Attack()
    {
        int maxTmp = 4;
        //if(player.isHallucinated == true) maxTmp = 8;

        if( enemyItself.Hp <= 0 )
            return false;
        else {
            float temp = ( enemyItself.FinalAttackPower() - player.FinalDefensePower() );

            if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Poison ) ) ) ) {
                temp += 1.0f;
            }
            if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Stunned ) ) ) ) {
                temp += 3.0f;
            }

            if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Adrenaline ) ) ) ) {
                temp *= 1.5f;
            }
            if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Morfin ) ) ) ) {
                temp *= 0.5f;
            }
            if( temp <= 1.0f )
                temp = 1;
            if( temp >= maxTmp ) temp = maxTmp;
            player.ChangeHp( -temp );

            if( player.Hp <= 0 )
                GameObject.Destroy( player );
            return true;
        }
    }

}
