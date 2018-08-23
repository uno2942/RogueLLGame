using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : Weapon { 
    public Lighter()
    {
        name = this.GetType().ToString();
        attackPower = 3;
        rank = "rare";
    }

    public override void Attack(Enemy enemy)
    {
        switch( rank ) {
        case "common": enemy.AddBuff( new Burn( 3 ) ); break;
        case "rare": enemy.AddBuff( new Burn( 4 ) ); break;
        case "legendary": enemy.AddBuff( new Burn( 5 ) ); break;
        default: return;
        }
    }
}
