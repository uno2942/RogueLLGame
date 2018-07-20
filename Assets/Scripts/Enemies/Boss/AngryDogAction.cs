using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryDogAction : EnemyAction {

    /** \nothing to do 
     */
    public AngryDogAction(Enemy enemy) : base(enemy){
    }
    public override void Other()
    {
        
    }
    
    /** \Double/triple Attack, heal itself
     */
    public override bool Attack() {
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

            //triple attack: shld check player's hallucinated 
            player.ChangeHp( -(int) temp );
            enemyItself.ChangeHp( (int) temp / 3 );
            player.ChangeHp( -(int) temp );
            enemyItself.ChangeHp( (int) temp / 3 );
            //if(player.isHallucinated == true)
            player.ChangeHp( -(int) temp );
            enemyItself.ChangeHp( (int) temp / 3 );


            if( player.Hp <= 0 )
                GameObject.Destroy( player );
            return true;
        }
    }
}
