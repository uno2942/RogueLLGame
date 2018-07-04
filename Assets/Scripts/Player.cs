using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : Unit {

    private float mp;
    private int hungry;
    private const int maxMp;
    private Inventory inventoryList;
    private PlayerAction action;
    /**
     * Player's mp and hungry degree.
     * Note that HP variable is in Unit class.
     */
    //{@
    public float Mp { get { return mp; } }
    public int MaxMp { get { return maxMp; } }
    public int Hungry { get { return hungry; } }
    //@}
    public PlayerAction Action
    {
        get
        {
            return action;
        }
    }

    public Inventory InventoryList
    {
        get
        {
            return inventoryList;
        }
    }

    public Weapon weapon;
    public Armor armor;
    /**
    * Player class have inventory gameobject to put items into inventory.
    */


    /**
     *Initialize the variables in Player class.
     *In this function, initialize HPBar, MPBar and inventory.
     */
    void Start() {
        attack = 1;
        defense = 1;
        hp = 120;
        mp = 120;
        hungry = 0;
        inventoryList = new Inventory();
        inventoryList.Initialize();
        GameObject.Find( "PlayerHPBar" ).GetComponent<Slider>().value = hp;
        GameObject.Find( "PlayerMPBar" ).GetComponent<Slider>().value = mp;
        action = new PlayerAction();
    }
    /**
     * It overrides ChangeHp function in Unit class to modify HPBar and MPBar Slider.
     */
    //{@
    public override void ChangeHp( float delta ) {
        hp += delta;
        GameObject.Find( "PlayerHPBar" ).GetComponent<Slider>().value = hp;
    }
    public void ChangeMp( float delta ) {
        mp += delta;
        GameObject.Find( "PlayerMPBar" ).GetComponent<Slider>().value = mp;
    }
    //@}
    public void ChangeHungry( int delta ) {
        hungry += delta;
    }






    /**
    * Legacy code
    * @see PlayerAction
    */
    //{@
    public void DumpItem( int index ) {
        action.DumpItem( index );
    }

    public void EatItem( int index ) {
        action.EatItem( index );
    }


    public void DrinkItem( int index ) {
        action.DrinkItem( index );
    }

    public void ThrowItem( int index ) {
        action.ThrowAwayItem( index );
    }
    public void EquipItem( int index ) {
        action.EquipItem( index );
    }

    public void UnequipItem( int index, bool GoNextTurn = true ) {
        action.UnequipItem( index, GoNextTurn );
    }
    /**
     * @todo I need to implement this part
     */
    public void TakeDrug( int index ) {
        action.TakeDrug( index );
    }
    //@}
}