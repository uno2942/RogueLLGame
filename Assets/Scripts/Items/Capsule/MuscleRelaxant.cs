using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * I need to count the used times of this capsule.
 */
public class MuscleRelaxant : Capsule {


    public override bool EattenBy( Player player ) {
        //if (player.musclecount < 5)
     //   {
            player.ChangeAttack(1);
            //player.Counts.muscle++;
      //  }
      //  else
            //dead mechanism

            return true;
    }
}
