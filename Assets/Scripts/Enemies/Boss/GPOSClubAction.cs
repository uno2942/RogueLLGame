using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPOSClubAction : EnemyAction
{
    private int prevboss;
    private int presboss;
    /** \decrease player's MP 1.2
     *  \
     */
    public GPOSClubAction(Enemy enemy) : base (enemy)
    {
    }

    public override void Other()
    {
        GPOSClub b = enemyItself as GPOSClub;
        b.Check ();
        presboss = b.Bosses;
        if(presboss == 1 && prevboss !=1 )
        {
            player.SetMpZero ();
        }
        prevboss = b.Bosses;
    }

    public override bool Attack()
    {
        GPOSClub b = enemyItself as GPOSClub;
        b.Check ();

        return base.Attack ();
    }
}

