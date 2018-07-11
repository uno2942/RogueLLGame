using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction {

    public enum Direction {Up, Down, Right, Left};
    public Player player;
    private ItemManager itemManager;
    private GameManager gameManager;
    public PlayerAction() {
        player = GameObject.Find( "Player" ).GetComponent<Player>();
        itemManager = GameObject.Find( "ItemManager" ).GetComponent<ItemManager>();
        gameManager= GameObject.Find( "GameManager" ).GetComponent<GameManager>();
    }


    public Inventory GetInventoryList() {
        return player.InventoryList;
    }

    /**
     * Player의 공격력과 상태를 기반으로 최종피해를 정한다.enemy의 체력을 깎고 Player.Weapon.Attack 메서드를 호출한다\
     * 공격 전 플레이어의 buff 상태와 착용한 무기를 확인하고,(방어구는 공격에 영향을 미치지 않는다.) 이를 공격력에 반영하여 공격 데미지를 결정한다.
     * 공격 후 적의 공격력이 0 이하가 되었을 때, enemy object를 destroy한다.(이는 죽은 적이 공격하지 않도록 하기 위함이다.)
     * @todo 중독/기절 보정이 뭔가요.
     */
    public void Attack( Enemy enemy ) {
        player.weapon.Attack( enemy ); //공격했을 때의 효과를 적에게 전달(데미지를 주지 않음).

        float temp = ( player.FinalAttackPower() - enemy.FinalDefensePower() );

        if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Adrenaline ) ) ) ) {
            temp *= 1.5f;
        }
        if( temp <= 1.0f )
            temp = 1;
        enemy.ChangeHp( -(int)temp );
        if( enemy.Hp <= 0 )
            GameObject.Destroy( enemy.gameObject );
        /*
        if (player.Bufflist.Exists( x => x.GetType().Equals( typeof(Poison) ) )) {
            temp += 1;
        }
        if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Poison ) ) ) )
        */
        Debug.Log( "공격 끝" );
        gameManager.EndPlayerTurn();
    }
    /**
    * 현재 위치정보를 기반으로 항을 변경한다
    */
    public void Move( Direction direction ) {

    }
    /**
     * 플레이어 위치의 방에서 아이템을 제거하고 플레이어의 인벤토리에 추가한다.
    * When item is clicked, this function invoked.
    * \see ItemPrefab::OnMouseUpAsButton
    */
    public void DumpItem( int index ) {
        player.InventoryList.DeleteItem( index );
        gameManager.EndPlayerTurn();
    }

    public void UseItem( int index ) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Expendable can = player.InventoryList.itemManager.LabelToItem( label ) as Expendable;
            can.UsedBy( player );
            DumpItem( index );
            gameManager.EndPlayerTurn();
        }
    }

    public void EatCapsule( int index ) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Capsule capsule = player.InventoryList.itemManager.LabelToItem( label ) as Capsule;
            capsule.EattenBy( player );
            player.InventoryList.itemManager.ItemIdentify( label );
            DumpItem( index );
            DumpItem( player.InventoryList.Getindex( ItemManager.Label.Water ) );
            player.InventoryList.IdentifyAllTheInventoryItem();
            gameManager.EndPlayerTurn();
        }
    }

    public void InjectItem( int index ) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Capsule capsule = player.InventoryList.itemManager.LabelToItem( label ) as Capsule;
            capsule.EattenBy( player );
            player.InventoryList.itemManager.ItemIdentify( label );
            DumpItem( index );
            gameManager.EndPlayerTurn();
        }
    }

    public void PickItem( ItemManager.Label label, GameObject _gameobject ) {
        if( player.InventoryList.AddItem( label ) == true ) {
            GameObject.Destroy( _gameobject );
            player.InventoryList.IdentifyAllTheInventoryItem();
        }
    }
    public void ThrowAwayItem( int index ) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Capsule capsule = player.InventoryList.itemManager.LabelToItem( label ) as Capsule;
            gameManager.Throw( label );

            //            if( true == inventoryList.itemManager.LabelToItem( label ).GetType().GetMethod( "ThrownTo" ).DeclaringType.Equals( inventoryList.itemManager.LabelToItem( label ) ) ) //ThrowTo가 구현(override) 되어있으면
            player.InventoryList.itemManager.ItemIdentify( label );
            player.InventoryList.IdentifyAllTheInventoryItem();
            gameManager.EndPlayerTurn();
        }
        DumpItem( index );
    }

    public void EquipItem( int index ) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Item weaponorarmor = player.InventoryList.itemManager.LabelToItem( label );
            if( weaponorarmor is Weapon ) {
                player.weapon = weaponorarmor as Weapon;
            } else
                player.armor = weaponorarmor as Armor;
            //장착되었으니 UI에서 뭔갈 해야함.
            gameManager.EndPlayerTurn();
        }
    }

    public void UnequipItem( int index, bool GoNextTurn = true ) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Item weaponorarmor = player.InventoryList.itemManager.LabelToItem( label );
            if( weaponorarmor is Weapon ) {
                player.weapon = null;
            } else
                player.armor = null;
            //장착되었으니 UI에서 뭔갈 해야함.
            if( GoNextTurn ) {
                gameManager.EndPlayerTurn();
            }
        }
    }

    public void TakeCapsule( int index ) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Capsule capsule = player.InventoryList.itemManager.LabelToItem( label ) as Capsule;
            capsule.EattenBy( player );
            player.InventoryList.itemManager.ItemIdentify( label );
            DumpItem( index );
            gameManager.EndPlayerTurn();
        }
    }

    /**
     * item을 사용하고 효과에 따른 메서드를 실행한다
     */
    public void UseItem( ItemManager.Label label ) {
        itemManager.LabelToItem( label );
    }
    public void Rest() {
    }
    /**
     *상태이상에 의해 아무것도 하지 않음
    */
    public void Uncontrolled() {
    }
    
}
