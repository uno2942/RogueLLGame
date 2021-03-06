﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction
{

    /** 
* \access on player to decrease player's hp
*/
    protected Player player;
    protected Enemy enemyItself;
    protected MessageMaker messageMaker;
    public EnemyAction(Enemy enemy) {
        player = GameObject.Find( "Player" ).GetComponent<Player>();
        messageMaker = GameObject.Find("Logger").GetComponent<MessageMaker>();
        enemyItself = enemy;
    }
    /** 
* \\ 모든 몹이 공통으로 사용하는 attack 함수로 데미지를 가한 후 특성화된 virtual debuff 발동
* \\ 인자로 Enemy를 받아야 한다(Player는 getcomponent로 접근)
* @todo 왜 changeHp(temp)이죠.
*/
    public virtual bool Attack()
    {
        if( enemyItself.Hp <= 0 )
            return false;
        else {
            float temp = ( enemyItself.FinalAttackPower() - player.FinalDefensePower() );
            if( player.FindBuff( new Poison( 1 ) ) != null )
                temp++;
            if( player.FindBuff( new Stunned( 3 ) ) != null )
                temp += 3;

            if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Poison ) ) ) ) {
                temp += 1.0f;
            }
            if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Stunned ) ) ) ) {
                temp += 3.0f;
            }

            if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Adrenaline ) ) ) ) {
                temp *= 1.2f;
            }
            if (player.Bufflist.Exists(x => x.GetType().Equals(typeof(Morfin))))
            {
                temp *= 0.5f;
            }
            if( temp <= 1.0f )
                temp = 1;
            player.ChangeHp( -temp );
            messageMaker.MakeAttackMessage(enemyItself, MessageMaker.UnitAction.Attack, player, (int)temp);
        float i = Random.value;
            if( i < enemyItself.DebuffPercent() ) {
                player.AddBuff( enemyItself.Debuff() );
            }
            if(player.armor is Padding) {
                Padding padding = player.armor as Padding;
                padding.OnAttacked();
            }
            return true;
        }
    }

    /**
     * \ 
     */
    
    /** 
* \special action for boss monsters : shld call always at enemy's turn
*/
    public virtual void Other()
    {

    }

}
