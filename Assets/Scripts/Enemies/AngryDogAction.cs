using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryDogAction : EnemyAction {


    Enemy enemyItself;
    /** \nothing to do 
     */
    public override void other()
    {
        
    }
    
    /** \Double/triple Attack, heal itself
     */
    public override void attackBy(Enemy enemy)
    {
        float temp = (enemy.FinalAttackPower() - player.FinalDefensePower());

        if (player.Bufflist.Exists(x => x.GetType().Equals(typeof(Poison))))
        {
            temp += 1.0f;
        }
        if (player.Bufflist.Exists(x => x.GetType().Equals(typeof(Paralyzed))))
        {
            temp += 3.0f;
        }

        if (player.Bufflist.Exists(x => x.GetType().Equals(typeof(Adrenaline))))
        {
            temp *= 1.5f;
        }
        if (player.Bufflist.Exists(x => x.GetType().Equals(typeof(Morfin))))
        {
            temp *= 0.5f;
        }
        if (temp <= 1.0f)
            temp = 1;

        //triple attack: shld check player's hallucinated 
        player.ChangeHp(-(int)temp);
        enemyItself.ChangeHp((int)temp / 3);
        player.ChangeHp(-(int)temp);
        enemyItself.ChangeHp((int)temp / 3);
        //if(player.isHallucinated == true)
        player.ChangeHp(-(int)temp);
        enemyItself.ChangeHp((int)temp / 3);
        

        if (player.Hp <= 0)
            GameObject.Destroy(player);
    }
}
