﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultArmor : Armor {
    public DefaultArmor() {
        name = this.GetType().ToString();
        defensivePowerMin = 0 ;
        defensivePowerMax = 1;
        rank = ItemManager.Rank.Common;
        }
}
