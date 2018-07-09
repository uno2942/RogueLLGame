﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expendable : Item {

    public virtual bool UsedBy( Player player ) {
        return true;
    }

    public virtual bool ExpandUseBy(Player player)
    {
        return true;
    }
}