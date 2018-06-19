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
    public void PickItem(ItemManager.Label label, GameObject _gameobject)
    {
        if( inventoryList.AddItem( label ) == true ) {
        Destroy( _gameobject );
        }
    }

    public ItemManager.Label GetLabel(int index)
    {
        return inventoryList.LabelList [index];
    }

    public Inventory GetInventoryList() {
        return inventoryList;
    }



    public void DumpItem( int index ) {
        inventoryList.DeleteItem( index );
        gameManager.EnemyTurn();
        gameManager.nextturn();
    }

    public void EatItem( int index ) {
        ItemManager.Label label = GetLabel( index );
        if( inventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Can can = inventoryList.itemManager.LabelToItem( label) as Can;
            can.EattenBy( this );
            DumpItem( index );
            gameManager.EnemyTurn();
            gameManager.nextturn();
        }
    }

    public void DrinkItem( int index ) {
        ItemManager.Label label = GetLabel( index );
        if( inventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Flask flask = inventoryList.itemManager.LabelToItem( label ) as Flask;
            flask.DrunkBy( this );
            inventoryList.itemManager.ItemIdentify( label );
            DumpItem( index );
            gameManager.EnemyTurn();
            gameManager.nextturn();
        }
    }
    public void ThrowItem( int index ) {
        ItemManager.Label label = GetLabel( index );
        if( inventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Flask flask = inventoryList.itemManager.LabelToItem( label ) as Flask;
            gameManager.Throw( label );

//            if( true == inventoryList.itemManager.LabelToItem( label ).GetType().GetMethod( "ThrownTo" ).DeclaringType.Equals( inventoryList.itemManager.LabelToItem( label ) ) ) //ThrowTo가 구현(override) 되어있으면
                inventoryList.itemManager.ItemIdentify( label );

            gameManager.EnemyTurn();
            gameManager.nextturn();
        }
        DumpItem( index );
    }
    public void EquipItem( int index ) {
        ItemManager.Label label = GetLabel( index );
        if( inventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            ItemAction weaponorarmor = inventoryList.itemManager.LabelToItem( label );
            if( weaponorarmor is Weapon ) {
                ChangeAttack( ( (Weapon) weaponorarmor ).AttackPower );
            } else
                ChangeDefense( ( (Armor) weaponorarmor ).DefensivePower );
            //장착되었으니 UI에서 뭔갈 해야함.
            gameManager.EnemyTurn();
            gameManager.nextturn();
        }
    }

    public void UnequipItem( int index, bool GoNextTurn=true ) {
        ItemManager.Label label = GetLabel( index );
        if( inventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            ItemAction weaponorarmor = inventoryList.itemManager.LabelToItem( label );
            if( weaponorarmor is Weapon ) {
                ChangeAttack( -(( Weapon) weaponorarmor ).AttackPower );
            } else
                ChangeDefense( -((Armor) weaponorarmor ).DefensivePower );
            //장착되었으니 UI에서 뭔갈 해야함.
            if( GoNextTurn ) {
                gameManager.EnemyTurn();
                gameManager.nextturn();
            }
        }
    }
}
