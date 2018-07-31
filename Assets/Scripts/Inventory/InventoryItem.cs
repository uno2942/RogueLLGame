﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * \brief 인벤토리에 들어가는 인벤토리 아이템 클래스(UI에 보이는 인벤토리 아이템 게임 오브젝트에 들어가는 클래스이다.)
 */
public class InventoryItem : MonoBehaviour {

    private int index;
    public bool isEquipped;
    public bool InjecCommuni;
    public bool MedicineCommuni;
    public NPC npc;
    private Player player;
    public GameObject[] dialogBox; //0: Weapon and Armor, 1: Expendable, 2: Capsule, 3. Injectors, 4. Card
    GameObject gObject;
    public int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = value;
        }
    }


    void Start() {
        player = GameObject.Find( "Player" ).GetComponent<Player>();
        isEquipped = false;
    }

    // Update is called once per frame
    void Update() {
        if (InjecCommuni == true||MedicineCommuni==true)
        {
            //반짝반짝 이펙트.
        }
    }
    /**
     * 인벤토리 아이템을 플레이어가 클릭했을 때 각 아이템의 라벨에 해당하는 선택 상자를 띄워준다.
     */
    void OnMouseUpAsButton() {
        if (InjecCommuni && false == player.GetInventoryList().isDialogBoxOn) {
            GivemeBox dBox;
            ItemManager.ItemType nowType = ItemManager.LabelToType(player.InventoryList.GetLabel(index));
            dBox = (gObject = Instantiate(dialogBox[1], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<GivemeBox>();
            dBox.inventoryItem = this;
            dBox.npc = this.npc;
            player.GetInventoryList().isDialogBoxOn = true;
        }
        else if (InjecCommuni && false == player.GetInventoryList().isDialogBoxOn)
        {
            MedicineBox dBox;
            ItemManager.ItemType nowType = ItemManager.LabelToType(player.InventoryList.GetLabel(index));
            dBox = (gObject = Instantiate(dialogBox[1], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<MedicineBox>();
            dBox.inventoryItem = this;
            player.GetInventoryList().isDialogBoxOn = true;
        }
        else if( false == player.GetInventoryList().isDialogBoxOn ) {
            DialogBox dBox;
            ItemManager.ItemType nowType = ItemManager.LabelToType( player.InventoryList.GetLabel( index ) );
            switch( nowType ) {
            case ItemManager.ItemType.Weapon:
            case ItemManager.ItemType.Armor: {
                    dBox = ( gObject = Instantiate( dialogBox[ 0 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<WeaponArmorDialogBox>();
                    dBox.inventoryItem = this;
                    WeaponArmorDialogBox W = dBox as WeaponArmorDialogBox;
                    ChangeButtonText( W );

                    player.GetInventoryList().isDialogBoxOn = true;
                    break;
                }
            case ItemManager.ItemType.Expenables: {
                    dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<ExpendableDialogBox>();
                    dBox.inventoryItem = this;
                    player.GetInventoryList().isDialogBoxOn = true;
                    break;
                }
            case ItemManager.ItemType.Capsule: {
                    dBox = ( gObject = Instantiate( dialogBox[ 2 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CapsuleDialogBox>();
                    dBox.inventoryItem = this;
                    player.GetInventoryList().isDialogBoxOn = true;
                    break;
                }
            default:
                return;

            }
        } else
            return;
    }
    /**
     * 무기와 갑옷을 장착했냐, 해제했냐에 따라서 선택 상자에 뜨는 텍스트를 다르게 해주는 함수
     * 예를 들어 플레이어가 장착하고 있다면 선택 상자에 "해재하겠습니까?"라는 텍스트가 떠야 한다.
     */
    private void ChangeButtonText( WeaponArmorDialogBox W) {
        int i;
        UnityEngine.UI.Button[] buttons = W.GetComponentsInChildren<UnityEngine.UI.Button>();
        for( i = 0; i < buttons.Length; i++ )
            if( buttons[ i ].name == "EquipandUnequip" )
                break;
        if( true == isEquipped ) {
            buttons[ i ].GetComponentInChildren<UnityEngine.UI.Text>().text = "해제하기";
        } else
            buttons[ i ].GetComponentInChildren<UnityEngine.UI.Text>().text = "장착하기";
    }

    /**
     * 플레이어가 선택 상자에서 아이템을 삭제하는 명령을 선택하였을 때 실행되는 함수
     * \see player::DumpItem
     */
    public void DumpCommand() {
        Destroy(gObject);
        player.GetInventoryList().isDialogBoxOn = false;
        if( true == isEquipped )
            player.UnequipItem( index, false );
        isEquipped = false;
        player.DumpItem( index );
    }

    /**
 * 플레이어가 선택 상자에서 아이템을 사용하는 명령을 선택하였을 때 실행되는 함수
 * \see player::UseItem
 */
    public void UseCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        player.UseItem( index );
    }
    /**
 * 플레이어가 선택 상자에서 캡슐을 먹는 명령을 선택하였을 때 실행되는 함수
 * \see player::EatCapsule
 */
    public void EatCapsuleCommand() {
        if( true == player.InventoryList.CheckItem( ItemManager.ItemCategory.Water ) ) {
            Destroy( gObject );
            player.GetInventoryList().isDialogBoxOn = false;
            player.EatCapsule( index );
        }  
    }
    /**
* 플레이어가 선택 상자에서 주사하는 명령을 선택하였을 때 실행되는 함수
* \see player::InjectItem
*/
    public void InjectCommand() {
        if( true == GameObject.Find( "Inventory" ).GetComponent<Inventory>().CheckItem( ItemManager.ItemCategory.Water ) ) {
            Destroy( gObject );
            player.GetInventoryList().isDialogBoxOn = false;
            player.InjectItem( index );
        }
    }
    /**
* 플레이어가 선택 상자에서 장착하는 명령을 선택하였을 때 실행되는 함수
* \see player::EquipItem
* @todo isEquipped를 armor, weapon에 해당하는 변수 2개를 만들어야 한다.
*/
    public void EquipCommand() {
        Destroy( gObject );//삭제?
        player.GetInventoryList().isDialogBoxOn = false;
        player.EquipItem( index );
        isEquipped = true;
    }
    /**
* 플레이어가 선택 상자에서 해제하는 명령을 선택하였을 때 실행되는 함수
* \see player::UnequipCommand
*/
    public void UnequipCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        player.UnequipItem( index );
        isEquipped = false;
    }
    /**
* 플레이어가 선택 상자에서 던지는 명령을 선택하였을 때 실행되는 함수
* \see player::ThrowCommand
*/
    public void ThrowCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        player.ThrowItem( index );
    }
    /**
* 플레이어가 선택 상자에서 취소하는 명령을 선택하였을 때 실행되는 함수
* \see player::CancelCommand
*/
    public void CancelCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
    }
}
