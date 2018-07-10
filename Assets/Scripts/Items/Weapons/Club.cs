using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : Weapon
{
    public Club()
    {
        name = this.GetType().ToString();
        attackPower = 9;
        rank = "common";
    }
}
