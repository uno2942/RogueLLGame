using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalDirectorAction : EnemyAction {

    /** \shld check Player's action before and change MP
     *  \Maybe this work can be done in Boss Room
     */
    public override void other()
    {
        /* 
        if(false) // player did attack
        {
            player.ChangeMp(-10);
        }
        if (false) // player did rest
        {
            player.ChangeMp(4);
        }
        */
    }

    /** \override to limit max damage
     */
    public override void attackBy(Enemy enemy)
    {
        int maxTmp = 4;
        //if(player.isHallucinated == true) maxTmp = 8;


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
        if (temp >= maxTmp) temp = maxTmp;
        player.ChangeHp(-(int)temp);


        

        if (player.Hp <= 0)
            GameObject.Destroy(player);
    }

}
