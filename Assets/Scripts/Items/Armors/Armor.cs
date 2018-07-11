using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equip{

    protected int defensivePower;

    public int DefensivePower
    {
        get
        {
            return defensivePower;
        }
    }

    public virtual void Check(Player player ) {

    }
}
