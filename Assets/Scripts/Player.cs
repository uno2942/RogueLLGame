using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit {

    private const int invenSize = 12;

    private int mp;
    private int hungry;
    private int [] itemList = new int [invenSize];
    private int equippedItem;

    public int Mp { get { return mp; } }
    public int Hungry { get { return hungry; } }
    public int [] ItemList { get { return itemList; } }
    public int EquippedItem { get { return equippedItem; } }

    private void Start()
    {
        Debug.Log ("생성");
        attack = 1;
        defense = 1;
        hp = 120;
        mp = 120;
        hungry = 0;
    }
    public void ChangeMp(int delta)
    {
        mp += delta;
    }

    public void ChangeHungry(int delta)
    {
        hungry += delta;
    }

    public bool isRelieve()
    {
        return statusList.isRelieve ();
    }
    public bool isAwaken()
    {
        return statusList.isAwaken ();
    }
}
