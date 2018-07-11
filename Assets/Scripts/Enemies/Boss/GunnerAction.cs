using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerAction : EnemyAction {

    /** \increase Attack By 33
     *  \ shld fix: chan
     */

    public GunnerAction( Enemy enemy ) : base( enemy ) {
    }

    int counter = 4;
    bool buffCalled = false;
    

    public override void Other()
    {
        if(enemyItself.Hp < 40 && buffCalled == false)
        {
            enemyItself.ChangeAttack(33 - enemyItself.Attack);
            buffCalled = true;
        }
        if(buffCalled == true && counter > 0)
        {
            counter--;
        }
        if(counter <= 0)
        {
            enemyItself.ChangeAttack(4 - enemyItself.Attack);
            //if hallucinated: changeAttack(6)
        }
    }
}
