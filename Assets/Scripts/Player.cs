using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : Unit {

    private const int invenSize = 12;

    private int mp;
    private int hungry;
    private Inventory inventoryList;
    private int equippedItem;

    public int Mp { get { return mp; } }
    public int Hungry { get { return hungry; } }
    public int EquippedItem { get { return equippedItem; } }

    void Start()
    {
        Debug.Log ("생성");
        attack = 1;
        defense = 1;
        hp = 120;
        mp = 120;
        hungry = 0;
        inventoryList = new Inventory ();
        inventoryList.Initialize ();
        GameObject.Find ("PlayerHPBar").GetComponent<Slider> ().value = hp;
        GameObject.Find ("PlayerMPBar").GetComponent<Slider> ().value = mp;
    }

    public override void ChangeHp(int delta)
    {
        hp += delta;
        GameObject.Find ("PlayerHPBar").GetComponent<Slider> ().value = hp;
    }
    public void ChangeMp(int delta)
    {
        mp += delta;
        GameObject.Find ("PlayerMPBar").GetComponent<Slider> ().value = mp;
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

    public void PickItem(ItemManager.Label label)
    {
        inventoryList.AddItem (label);
    }
    public ItemManager.Label GetLabel(int index)
    {
        return inventoryList.LabelList [index];
    }
}
