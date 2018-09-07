using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * \brief 플레이어가 할 수 있는 Action들의 집합 클래스
 */
public class PlayerAction {

    public enum Direction {Up, Down, Right, Left};
    public Player player;
    private ItemManager itemManager;
    private GameManager gameManager;
    private MessageMaker messageMaker;
    private BoardManager boardmanager;
    public bool bossCommuni;
    public PlayerAction() {
        player = GameObject.Find( "Player" ).GetComponent<Player>();
        itemManager = GameObject.Find( "ItemManager" ).GetComponent<ItemManager>();
        gameManager= GameObject.Find( "GameManager" ).GetComponent<GameManager>();
        messageMaker = GameObject.Find("Logger").GetComponent<MessageMaker>();
        boardmanager = GameObject.Find ("BoardManager").GetComponent<BoardManager> ();
        bossCommuni = false;
    }


    /**
     * Player의 공격력과 상태를 기반으로 최종피해를 정한다.enemy의 체력을 깎고 Player.Weapon.Attack 메서드를 호출한다\
     * 공격 전 플레이어의 buff 상태와 착용한 무기를 확인하고,(방어구는 공격에 영향을 미치지 않는다.) 이를 공격력에 반영하여 공격 데미지를 결정한다.
     * 공격 후 적의 공격력이 0 이하가 되었을 때, enemy object를 destroy한다.(이는 죽은 적이 공격하지 않도록 하기 위함이다.)
     * @todo 중독/기절 보정이 뭔가요.
     */
    public void Attack( Enemy enemy ) {

        if ( enemy is HospitalDirector )
        {
            player.ChangeMp (-10);

            int tempindex;
            player.weapon.Attack (enemy); //공격했을 때의 효과를 적에게 전달(데미지를 주지 않음).

            float temp = (player.FinalAttackPower () - enemy.FinalDefensePower ());

            if ( player.Bufflist.Exists (x => x.GetType ().Equals (typeof (Adrenaline))) )
            {
                temp *= 1.6f;
            }
            if ( temp <= 1.0f )
                temp = 1;
            if ( player.FinalAttackPower () <= 0 )
                temp = 0;

            int stop = 0;
            if ( player.isHallucinated )
                stop = 6;
            else
                stop = 12;

            if ( temp >= stop )
                enemy.ChangeHp (-stop);
            else
                enemy.ChangeHp (-temp);
            messageMaker.MakeAttackMessage (player, MessageMaker.UnitAction.Attack, enemy, (int) temp);

            if ( enemy.Hp <= 0 )
            {
                messageMaker.MakeDeathMessage (player, enemy);
                gameManager.KillEnemy (enemy);
            }

            if ( player.weapon.IsDestroyed () == true )
            {
                tempindex = player.weaponindex;
                UnequipItem (tempindex);
                DumpItem (tempindex);
            }

            Debug.Log ("공격 끝");
            gameManager.EndPlayerTurn (Unit.Action.Attack);
        }
        else
        {
            int tempindex;
            player.weapon.Attack (enemy); //공격했을 때의 효과를 적에게 전달(데미지를 주지 않음).

            float temp = (player.FinalAttackPower () - enemy.FinalDefensePower ());

            if ( player.Bufflist.Exists (x => x.GetType ().Equals (typeof (Adrenaline))) )
            {
                temp *= 1.6f;
            }
            if ( temp <= 1.0f )
                temp = 1;
            if ( player.FinalAttackPower () <= 0 )
                temp = 0;
            enemy.ChangeHp (-temp);
            messageMaker.MakeAttackMessage (player, MessageMaker.UnitAction.Attack, enemy, (int) temp);

            if ( enemy.Hp <= 0 )
            {
                messageMaker.MakeDeathMessage (player, enemy);
                gameManager.KillEnemy (enemy);
            }
            /*
            if (player.Bufflist.Exists( x => x.GetType().Equals( typeof(Poison) ) )) {
                temp += 1;
            }
            if( player.Bufflist.Exists( x => x.GetType().Equals( typeof( Poison ) ) ) )
            */
            if ( player.weapon.IsDestroyed () == true )
            {
                tempindex = player.weaponindex;
                UnequipItem (tempindex);
                DumpItem (tempindex);
            }

            Debug.Log ("공격 끝");
            gameManager.EndPlayerTurn (Unit.Action.Attack);
        }
    }
    /**
    * 현재 위치정보를 기반으로 항을 변경한다
    */
    public void Move( Direction direction ) {

    }
    /**
     * 아이템을 버린다.
     * \see Player::DumpItem
     * \see InventoryItem::DumpCommand
    */
    public void DumpItem( int index ) {
        player.InventoryList.DeleteItem( index );
        gameManager.EndPlayerTurn( Unit.Action.Items );
    }
    /**
     * \see InventoryItem::UseItem
     * \see Player::UseItem
     */
    public void UseItem( int index ) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Debug.Log(System.Enum.GetName(typeof(ItemManager.Label), label));
            Debug.Log(System.Enum.GetName(typeof(ItemManager.Label), label)+"(Clone)");
            
            foreach(GameObject gObject in GameObject.FindGameObjectsWithTag("ItemPickedUp"))
            {/*
                if(gObject.name==System.Enum.GetName(typeof(ItemManager.Label), label)+"(Clone)")
                    {gObject.GetComponent<ItemECS>().isUse=true;
                    break;
                    }*/
                if( gObject.GetComponent<ItemPrefab>().label == player.InventoryList.LabelList[ index ] ) {
                    gObject.GetComponent<ItemECS>().isUse = true;
                    player.InventoryList.itemManager.ItemIdentify( label );
                    break;
                }
            }
                            
            
            DumpItem( index );
        }
    }

    public void SpreadWater(int index ) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {

            foreach( GameObject gObject in GameObject.FindGameObjectsWithTag( "ItemPickedUp" ) ) {
                if( gObject.name == System.Enum.GetName( typeof( ItemManager.Label ), label ) + "(Clone)" ) {
                    GameObject.Destroy( gObject );
                    player.DeleteBuff( new Burn( 1 ) );
                    break;
                }
            }
            messageMaker.MakeItemMessage( MessageMaker.UnitAction.UseItem, player.InventoryList.LabelList[ index ] );
            DumpItem( index );
        }
    }

    public void PickItem( ItemManager.Label label ) {
        if( player.InventoryList.AddItem( label ) == true ) {
            messageMaker.MakeItemMessage( MessageMaker.UnitAction.PickItem, label );
            player.InventoryList.IdentifyAllTheInventoryItem();
            gameManager.EndPlayerTurn( Unit.Action.Items );
        }
    }
    /**
* \see InventoryItem::ThrowCommand
* \see Player::ThrowItem
*/
    public void ThrowAwayItem( int index ) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            gameManager.Throw( label );

            //            if( true == inventoryList.itemManager.LabelToItem( label ).GetType().GetMethod( "ThrownTo" ).DeclaringType.Equals( inventoryList.itemManager.LabelToItem( label ) ) ) //ThrowTo가 구현(override) 되어있으면
            player.InventoryList.itemManager.ItemIdentify( label );
            player.InventoryList.IdentifyAllTheInventoryItem();
            
        }
        DumpItem( index );
    }
    /**
* \see InventoryItem::EquipCommand
* \see Player::EquipItem
*/
    public void EquipItem( int index ) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Item weaponorarmor = player.InventoryList.itemManager.LabelToItem( label );
            if( weaponorarmor is Weapon ) {
                player.weapon = player.InventoryList.weapons[ index ];
                player.weaponindex = index;
                GameObject.Find( "WeaponImage" ).GetComponent<UnityEngine.UI.Image>().sprite = itemManager.LabelToSprite( label );
            } else 
            { player.armor = player.InventoryList.armors[ index ];
                player.armorindex = index;
                GameObject.Find( "ArmorImage" ).GetComponent<UnityEngine.UI.Image>().sprite = itemManager.LabelToSprite( label );
            }
        }
        gameManager.EndPlayerTurn( Unit.Action.Items );
    }
    /**
* \see InventoryItem::UnequipCommand
* \see Player::UnequipItem
*/
    public void UnequipItem( int index) {
        ItemManager.Label label = player.InventoryList.GetLabel( index );
        if( player.InventoryList.LabelList[ index ] != ItemManager.Label.Empty ) {
            Item weaponorarmor = player.InventoryList.itemManager.LabelToItem( label );
            if( weaponorarmor is Weapon ) {
                player.weapon = new DefaultWeapon();
                player.weaponindex = -1;
                GameObject.Find( "WeaponImage" ).GetComponent<UnityEngine.UI.Image>().sprite = null;
            } else {
                player.armor = new DefaultArmor();
                player.armorindex = -1;
                GameObject.Find( "WeaponImage" ).GetComponent<UnityEngine.UI.Image>().sprite = null;
            }
        }
        gameManager.EndPlayerTurn( Unit.Action.Items );
    }

    /**
     * @todo I need to delete this function?
     */


    /**
     * item을 사용하고 효과에 따른 메서드를 실행한다
     */
    public void UseItem( ItemManager.Label label ) {
        itemManager.LabelToItem( label );
    }

    public void Rest()
    {
        if ( bossCommuni )
            player.ChangeMp (6);

        player.ChangeHp( 1 );
        gameManager.EndPlayerTurn( Unit.Action.Rest );
    }
    /**
     *상태이상에 의해 아무것도 하지 않음
    */
    public void Uncontrolled() {
    }


}
