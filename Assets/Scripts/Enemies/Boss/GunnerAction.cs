using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerAction : EnemyAction {

    /** \increase Attack By 33
     *  \ shld fix: chan
     */

    public GunnerAction( Enemy enemy ) : base( enemy ) {
    }
    

    public override bool Attack() {

        Gunner b = enemyItself as Gunner;
        if( enemyItself.Hp < 90 )
            b.atkBuffOn = true;

        if( b.atkBuffOn ) b.atkBuffTurn++;

        if( b.atkBuffTurn > 0 && b.atkBuffTurn < 5 ) {
            int tmpAtk = b.Attack;
            b.ChangeAttack( 10 - b.Attack );
            b.ChangeAttack( tmpAtk - b.Attack );
            
        }


        if( enemyItself.Hp <= 0 )
            return false;
        else {
            int tmpAtk = b.Attack;
            if( b.atkBuffTurn > 0 && b.atkBuffTurn < 5 ) { //잠시 공격력을 10으로
                b.ChangeAttack( 10 - b.Attack );
            }

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
            player.ChangeHp( -temp );
            messageMaker.MakeAttackMessage( enemyItself, MessageMaker.UnitAction.Attack, player, (int) temp );

            if( b.atkBuffTurn > 0 && b.atkBuffTurn < 5 ) { //원래대로 돌리고
                b.ChangeAttack( tmpAtk - b.Attack );
            }

            
            if( temp >= 10 ) {
                player.AddBuff( enemyItself.Debuff() );
            }

            return true;
        }

    }

}
