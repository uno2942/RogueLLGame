using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status {
    private int remainTurn;
    private bool isActive;
    protected Unit unit;

    public int RemainTurn
    {
        get
        {
            return remainTurn;
        }

        set
        {
            remainTurn = value;
        }
    }

    public bool IsActive
    {
        get
        {
            return isActive;
        }

        set
        {
            isActive = value;
        }
    }

    public Unit Unit
    {
        get
        {
            return unit;
        }

        set
        {
            unit = value;
        }
    }

    // Use this for initialization
    public Status() {
        remainTurn = 0;
        isActive = false;
    }
	
    public virtual void DoAction()
    {
    }
    public virtual void Activate()
    {
        isActive = true;
    }
    public virtual void Inactivate()
    {
        isActive = false;
    }
}
