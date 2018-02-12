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
        Debug.Log( label );
        inventoryList.AddItem (label);
    }

    public ItemManager.Label GetLabel(int index)
    {
        return inventoryList.LabelList [index];
    }





    public void DumpItem( int index ) {
        inventoryList.DeleteItem( index );
    }

    public void EatItem( int index ) {
        ItemManager.Label label = GetLabel( index );
        if( inventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Can can = inventoryList.itemManager.LabelToItem( label) as Can;
            can.EattenBy( this );
            DumpItem( index );
        }
    }

    public void DrinkItem( int index ) {
        ItemManager.Label label = GetLabel( index );
        if( inventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Flask flask = inventoryList.itemManager.LabelToItem( label ) as Flask;
            flask.DrunkBy( this );
            inventoryList.itemManager.ItemIdentify( label );
            DumpItem( index );
        }
    }
    public void ThrowItem( int index ) {
        ItemManager.Label label = GetLabel( index );
        if( inventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Flask flask = inventoryList.itemManager.LabelToItem( label ) as Flask;
           // flask.ThrownTo( );
        }
        DumpItem( index );
    }
    public void EquipItem( int index ) {
        ItemManager.Label label = GetLabel( index );
        if( inventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Object weaponorarmor = inventoryList.itemManager.LabelToItem( label );
            if( weaponorarmor is Weapon ) {
                Debug.Log( weaponorarmor.GetType() );
                Debug.Log( ( (Weapon) weaponorarmor ).AttackPower );
                ChangeAttack( ( (Weapon) weaponorarmor ).AttackPower );
            } else
                ChangeDefense( ( (Armor) weaponorarmor ).DefensivePower );
            //장착되었으니 뭔갈 해야함.
        }
        Debug.Log( attack );
    }

    public void UnequipItem( int index ) {
        ItemManager.Label label = GetLabel( index );
        if( inventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Object weaponorarmor = inventoryList.itemManager.LabelToItem( label );
            if( weaponorarmor is Weapon ) {
                ChangeAttack( -(( Weapon) weaponorarmor ).AttackPower );
            } else
                ChangeDefense( -((Armor) weaponorarmor ).DefensivePower );
            //장착되었으니 뭔갈 해야함.
        }
    }
}
