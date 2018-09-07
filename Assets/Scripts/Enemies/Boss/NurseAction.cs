using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseAction : EnemyAction {
    
    
    bool healCalled = false;


    public NurseAction( Enemy enemy ) : base( enemy ) {
    }

    /** \check for heal pattern
     */
    public override void Other()
    {
        /*if (enemyItself.Hp < 100 && healCalled == false)
        {
            enemyItself.ChangeHp(enemyItself.MaxHp - enemyItself.Hp);
            player.ChangeMp(player.MaxMp - player.Mp);
            healCalled = true;
        }*/
        Nurse b = enemyItself as Nurse;
        if ( b.Hp < 100 && healCalled == false )
        {
            b.ChangeHp (enemyItself.MaxHp - enemyItself.Hp);
            player.ChangeMp (player.MaxMp - player.Mp);
            healCalled = true;
        }
    }

    /** \override for give buffs: 
     */
    public override bool Attack() {
        Nurse b = enemyItself as Nurse;
        if ( enemyItself.Hp < 100 )
            b.atkBuffOn = true;

        if ( b.atkBuffOn ) b.atkBuffTurn++;

        if ( b.atkBuffTurn == 1 )
            b.ChangeHp (225 - b.Hp);


        if ( enemyItself.Hp <= 0 )
            return false;
        else
        {
            float temp = (enemyItself.FinalAttackPower () - player.FinalDefensePower ());

            if ( player.Bufflist.Exists (x => x.GetType ().Equals (typeof (Poison))) )
            {
                temp += 1.0f;
            }
            if ( player.Bufflist.Exists (x => x.GetType ().Equals (typeof (Stunned))) )
            {
                temp += 3.0f;
            }

            if ( player.Bufflist.Exists (x => x.GetType ().Equals (typeof (Adrenaline))) )
            {
                temp *= 1.5f;
            }
            if ( player.Bufflist.Exists (x => x.GetType ().Equals (typeof (Morfin))) )
            {
                temp *= 0.5f;
            }
            if ( temp <= 1.0f )
                temp = 1;
            player.ChangeHp (-temp);
            messageMaker.MakeAttackMessage (enemyItself, MessageMaker.UnitAction.Attack, player, (int) temp);
            

            if ( temp >= 4 )
            {
                player.AddBuff (enemyItself.Debuff ());
            }

            return true;
        }
    }
}
