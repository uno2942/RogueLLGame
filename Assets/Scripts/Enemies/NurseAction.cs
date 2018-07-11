using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseAction : EnemyAction {

    Enemy enemyItself;
    
    bool healCalled = false;



    /** \check for heal pattern
     */
    public override void other()
    {
        if (enemyItself.Hp < 100 && healCalled == false)
        {
            enemyItself.ChangeHp(enemyItself.MaxHp - enemyItself.Hp);
            player.ChangeMp(player.MaxMp - player.Mp);
            healCalled = true;
        }
        
    }

    /** \override for give buffs: 
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
        player.ChangeHp(-(int)temp);

        
        if (temp > 1)
        {
            //player.Addbuff(new 방깎버프(5))
        }
        if (temp >= 7)
        {
            player.AddBuff(new Bleed(3));
        }

        if (player.Hp <= 0)
            GameObject.Destroy(player);
    }
}
