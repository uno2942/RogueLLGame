using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * \brief 인벤토리에 들어가는 인벤토리 아이템 클래스(UI에 보이는 인벤토리 아이템 게임 오브젝트에 들어가는 클래스이다.)
 */
public class InventoryItem : MonoBehaviour {

    private int index = -1;
    public bool InjecCommuni;
    public bool MedicineCommuni;
    private MessageMaker messageMaker;
    public NPC npc;
    private Player player;
    public GameObject[] dialogBox; //0: Weapon and Armor, 1: Expendable, 2: Capsule, 3. Injectors, 4. Card, 5. Water
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
        messageMaker = GameObject.Find( "Logger" ).GetComponent<MessageMaker>();
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
    public void OnClicked() {
       /* if( false == player.GetInventoryList().isDialogBoxOn && ItemManager.Label.Water== player.InventoryList.GetLabel( index ) )
            {
            DialogBox dBox;
            dBox = ( gObject = Instantiate( dialogBox[ 5 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<ExpendableDialogBox>();
            dBox.inventoryItem = this;
            player.GetInventoryList().isDialogBoxOn = true;

        } else */if (player.InventoryList.InjecCommuni) {
            /*GivemeBox dBox;
            ItemManager.ItemType nowType = ItemManager.LabelToType(player.InventoryList.GetLabel(index));
            dBox = (gObject = Instantiate(dialogBox[1], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<GivemeBox>();
            dBox.inventoryItem = this;
            dBox.npc = this.npc as InjectorCollector;
            player.GetInventoryList().isDialogBoxOn = true;*/
            //1. dialogbox 요소 가져오기
            Debug.Log( "Hi I am GivemeBox" );
            GivemeBox gBox = GameObject.Find( "Giveme(Clone)" ).GetComponent<GivemeBox>();
            //2. dialogbox 요소에 정보와 사진 때려박기
            if( ItemManager.ItemType.Injector == ItemManager.LabelToType( player.InventoryList.GetLabel( index ) ) ) {
                gBox.injector = player.InventoryList.GetLabel( index );
                ItemManager itemManager = GameObject.Find( "ItemManager" ).GetComponent<ItemManager>();
                GameObject.FindWithTag("GivemeBoxImage").GetComponent< UnityEngine.UI.Image >().sprite = itemManager.LabelToSprite( gBox.injector );                              
            } else {
                Debug.Log( "주사기 아님" );
                
            }
                       
        }

        else if (player.InventoryList.MedicineCommuni)
        {
            //1. dialogbox 요소 가져오기
            Debug.Log( "Hi I am GivemeBox" );
            SelectBox gBox = GameObject.Find( "Select(Clone)" ).GetComponent<SelectBox>();
            //2. dialogbox 요소에 정보와 사진 때려박기
            if( ItemManager.ItemType.Capsule == ItemManager.LabelToType( player.InventoryList.GetLabel( index ) ) ) {
                gBox.pill = player.InventoryList.GetLabel( index );
                ItemManager itemManager = GameObject.Find( "ItemManager" ).GetComponent<ItemManager>();
                GameObject.FindWithTag( "SelectBoxImage" ).GetComponent<UnityEngine.UI.Image>().sprite = itemManager.LabelToSprite( gBox.pill );
            } else {
                Debug.Log( "알약 아님" );
            }
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

                    foreach( UnityEngine.UI.Text text in dBox.GetComponentsInChildren<UnityEngine.UI.Text>()) {
                        if( text.gameObject.name == "Description" )
                            text.text = ItemManager.DescriptionOfItem( ItemManager.LabelToCategory( player.InventoryList.GetLabel( index ) ) );
                    }
                    player.GetInventoryList().isDialogBoxOn = true;
                    break;
                }
            case ItemManager.ItemType.Expenables: {
                    if( player.InventoryList.GetLabel( index ) != ItemManager.Label.Water ) {
                        dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<ExpendableDialogBox>();
                        dBox.inventoryItem = this;
                        foreach( UnityEngine.UI.Text text in dBox.GetComponentsInChildren<UnityEngine.UI.Text>() ) {
                            if( text.gameObject.name == "Description" )
                                text.text = ItemManager.DescriptionOfItem( ItemManager.LabelToCategory( player.InventoryList.GetLabel( index ) ) );
                        }
                        player.GetInventoryList().isDialogBoxOn = true;
                    } else {
                        dBox = ( gObject = Instantiate( dialogBox[ 5 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<WaterDialogBox>();
                        dBox.inventoryItem = this;
                        foreach( UnityEngine.UI.Text text in dBox.GetComponentsInChildren<UnityEngine.UI.Text>() ) {
                            if( text.gameObject.name == "Description" )
                                text.text = ItemManager.DescriptionOfItem( ItemManager.LabelToCategory( player.InventoryList.GetLabel( index ) ) );
                        }
                        player.GetInventoryList().isDialogBoxOn = true;
                    }
                    break;
                }
            case ItemManager.ItemType.Capsule: {
                    dBox = ( gObject = Instantiate( dialogBox[ 2 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CapsuleDialogBox>();
                    dBox.inventoryItem = this;
                    foreach( UnityEngine.UI.Text text in dBox.GetComponentsInChildren<UnityEngine.UI.Text>() ) {
                        if( text.gameObject.name == "Description" ) {
                            if( GameObject.Find( "ItemManager" ).GetComponent<ItemManager>().GetItemIdentificationInfo( player.InventoryList.GetLabel( index ) ) )
                                text.text = ItemManager.DescriptionOfItem( ItemManager.LabelToCategory( player.InventoryList.GetLabel( index ) ) );
                            else
                                text.text = "뭘까요.";
                        }
                    }
                    player.GetInventoryList().isDialogBoxOn = true;
                    break;
                }
            case ItemManager.ItemType.Injector: {
                    dBox = ( gObject = Instantiate( dialogBox[ 3 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<InjectorDialogBox>();
                    dBox.inventoryItem = this;
                    foreach( UnityEngine.UI.Text text in dBox.GetComponentsInChildren<UnityEngine.UI.Text>() ) {
                        if( text.gameObject.name == "Description" )
                            text.text = ItemManager.DescriptionOfItem( ItemManager.LabelToCategory( player.InventoryList.GetLabel( index ) ) );
                    }
                    player.GetInventoryList().isDialogBoxOn = true;
                    break;  
                }

            case ItemManager.ItemType.Card: {
              /*      foreach( UnityEngine.UI.Text text in dBox.GetComponentsInChildren<UnityEngine.UI.Text>() ) {
                        if( text.gameObject.name == "Description" )
                            text.text = ItemManager.DescriptionOfItem( ItemManager.LabelToCategory( player.InventoryList.GetLabel( index ) ) );
                    }
                    dBox = ( gObject = Instantiate( dialogBox[ 4 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CapsuleDialogBox>();
                    dBox.inventoryItem = this;
                    player.GetInventoryList().isDialogBoxOn = true;*/
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
        if( player.weaponindex == index || player.armorindex == index) {
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
        player.InventoryList.weapons[ index ] = null;
        player.InventoryList.armors[ index ] = null;
        if( player.weaponindex == index || player.armorindex == index ) {
            player.UnequipItem( index );
        }
        player.DumpItem( index );
        player.GetInventoryList().isDialogBoxOn = false;
        GameObject.Find( "GameManager" ).GetComponent<GameManager>().ThrowFlag = false;
    }

    /**
 * 플레이어가 선택 상자에서 아이템을 사용하는 명령을 선택하였을 때 실행되는 함수
 * \see player::UseItem
 */
    public void UseCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        messageMaker.MakeItemMessage( MessageMaker.UnitAction.UseItem, player.InventoryList.LabelList[ index ] );
        GameObject.Find( "GameManager" ).GetComponent<GameManager>().ThrowFlag = false;
        player.UseItem( index );
        }
    //물뿌릴대 부르는 함수
    public void SpreadCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        player.SpreadWater( index );
        messageMaker.MakeSpreadMessage();
    }
    /**
 * 플레이어가 선택 상자에서 캡슐을 먹는 명령을 선택하였을 때 실행되는 함수
 * \see player::EatCapsule
 */
    public void EatCapsuleCommand() {
                
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        if (false == player.InventoryList.CheckItem(ItemManager.ItemCategory.Water))
        {
            messageMaker.MakeItemMessage(MessageMaker.UnitAction.UseItem, player.InventoryList.LabelList[index], false);
            player.ChangeMp(-20);

        }
        else
        {
            messageMaker.MakeItemMessage(MessageMaker.UnitAction.UseItem, player.InventoryList.LabelList[index], true);
            player.DumpItem(ItemManager.Label.Water);
        }
        GameObject.Find( "GameManager" ).GetComponent<GameManager>().ThrowFlag = false;
        player.UseItem( index );
             
            

    }
    /**
* 플레이어가 선택 상자에서 주사하는 명령을 선택하였을 때 실행되는 함수
* \see player::InjectItem
*/
    public void InjectCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;

        Buff adTemp = new Adrenaline( 1 );
        Buff ad = player.FindBuff(adTemp);
        Buff moTemp = new Morfin( 1 );
        Buff mo = player.FindBuff(moTemp);

        if( (ItemManager.LabelToCategory(player.InventoryList.LabelList[ index ]) == ItemManager.ItemCategory.AdrenalineDrug  &&  mo != null )
            || ( ItemManager.LabelToCategory( player.InventoryList.LabelList[ index ] ) == ItemManager.ItemCategory.MorfinDrug && ad != null ) ) {
            messageMaker.MakeCannotMessage( player.InventoryList.LabelList[ index ] );
            return;
        }

        messageMaker.MakeItemMessage( MessageMaker.UnitAction.UseItem, player.InventoryList.LabelList[ index ] );
        player.UseItem( index );
        
    }
    /**
* 플레이어가 선택 상자에서 장착하는 명령을 선택하였을 때 실행되는 함수
* \see player::EquipItem
* @todo isEquipped를 armor, weapon에 해당하는 변수 2개를 만들어야 한다.
*/
    public void EquipCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        if( ItemManager.LabelToType( player.InventoryList.GetLabel( index ) ) == ItemManager.ItemType.Weapon && player.weaponindex != -1 )
            player.UnequipItem( player.weaponindex );
        else if( ItemManager.LabelToType( player.InventoryList.GetLabel( index ) ) == ItemManager.ItemType.Armor && player.armorindex != -1 )
            player.UnequipItem( player.armorindex );
        player.EquipItem( index );
    }
    /**
* 플레이어가 선택 상자에서 해제하는 명령을 선택하였을 때 실행되는 함수
* \see player::UnequipCommand
*/
    public void UnequipCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        player.UnequipItem( index );
    }
    /**
* 플레이어가 선택 상자에서 던지는 명령을 선택하였을 때 실행되는 함수
* \see player::ThrowCommand
*/
    public void ThrowCommand() {
        player.ThrowItem( index );
        GameObject.Find( "GameManager" ).GetComponent<GameManager>().ThrowObject = gObject;
    }
    /**
* 플레이어가 선택 상자에서 취소하는 명령을 선택하였을 때 실행되는 함수
* \see player::CancelCommand
*/
    public void CancelCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        GameObject.Find( "GameManager" ).GetComponent<GameManager>().ThrowFlag = false;
    }
}
