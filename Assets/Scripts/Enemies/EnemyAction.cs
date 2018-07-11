using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction
{

    /** 
* \access on player to decrease player's hp
*/
    private Player player;
    private Enemy enemyItself;
    public EnemyAction(Enemy enemy) {
        player = GameObject.Find( "Player" ).GetComponent<Player>();
        enemyItself = enemy;
    }
    /** 
* \\ 모든 몹이 공통으로 사용하는 attack 함수로 데미지를 가한 후 특성화된 virtual debuff 발동
* \\ 인자로 Enemy를 받아야 한다(Player는 getcomponent로 접근)
*/
    public virtual bool attackBy(Enemy enemy)
    {
        if( enemyItself.Hp <= 0 )
            return false;
        else {
            float temp = ( enemyItself.FinalAttackPower() - player.FinalDefensePower() );

            if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Poison ) ) ) ) {
                temp += 1.0f;
            }
            if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Paralyzed ) ) ) ) {
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
            player.ChangeHp( -(int) temp );

            float i = Random.value;
            if( i < enemyItself.DebuffPercent() ) {
                player.AddBuff( enemyItself.Debuff() );
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
