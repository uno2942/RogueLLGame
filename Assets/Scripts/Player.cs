using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : Unit {


    private int mp;
    private int hungry;
    /**
     * Player class have inventory gameobject to put items into inventory.
     */
    private Inventory inventoryList;
    /**
     * Player's mp and hungry degree.
     * Note that HP variable is in Unit class.
     */
     //{@
    public int Mp { get { return mp; } }
    public int Hungry { get { return hungry; } }
    //@}
    /**
     *Initialize the variables in Player class.
     *In this function, initialize HPBar, MPBar and inventory.
     */
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
    /**
     * It overrides ChangeHp function in Unit class to modify HPBar and MPBar Slider.
     */
     //{@
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
    //@}
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
    /**
     * When item is clicked, this function invoked.
     * \see Item::OnMouseUpAsButton
     */
    public void PickItem(ItemManager.Label label)
    {
        inventoryList.AddItem (label);
    }
}
