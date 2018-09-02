using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {
    protected int defaultA;
    protected int defaultD;
    protected int delA;
    protected int delD;

    public override void ChangeStatus(bool isHallucinated)
    {
        if (isHallucinated)
        {
            attack = defaultA + delA;
            defense = defaultD + delD;

        }
        else
        {
            attack = defaultA;
            defense = defaultD;
        }
    }

}
