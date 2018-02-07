using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    private const int invenSize = 12;

    protected int level;
    protected int number;
    public int Level { get { return level; } }
    public void changeLevel(int delta)
    {
        level += delta;
    }
    
   
}
