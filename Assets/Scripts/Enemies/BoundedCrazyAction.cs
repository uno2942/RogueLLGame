﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedCrazyAction : EnemyAction {

    /** \decrease player's MP 1.2
     *  \
     */


    public override void other()
    {
        player.ChangeMp(-1.2f);

    }
}
