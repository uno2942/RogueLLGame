using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {

    private int index;
    public bool isEquipped;
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

    }

    void OnMouseUpAsButton() {
            if( false == player.Action.GetInventoryList().isDialogBoxOn ) {
            DialogBox dBox;
            ItemManager.ItemType nowType = ItemManager.LabelToType( player.InventoryList.GetLabel( index ) );
            switch( nowType ) {
            case ItemManager.ItemType.Weapon:
            case ItemManager.ItemType.Armor: {
                    dBox = ( gObject = Instantiate( dialogBox[ 0 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<WeaponArmorDialogBox>();
                    dBox.inventoryItem = this;
                    WeaponArmorDialogBox W = dBox as WeaponArmorDialogBox;
                    ChangeButtonText( W );

                    player.Action.GetInventoryList().isDialogBoxOn = true;
                    break;
                }
            case ItemManager.ItemType.Expenables: {
                    dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<ExpendableDialogBox>();
                    dBox.inventoryItem = this;
                    player.Action.GetInventoryList().isDialogBoxOn = true;
                    break;
                }
            case ItemManager.ItemType.Capsule: {
                    dBox = ( gObject = Instantiate( dialogBox[ 2 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CapsuleDialogBox>();
                    dBox.inventoryItem = this;
                    player.Action.GetInventoryList().isDialogBoxOn = true;
                    break;
                }
            default:
                return;

            }
        } else
            return;
    }

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


    public void DumpCommand() {
        Destroy(gObject);
        player.Action.GetInventoryList().isDialogBoxOn = false;
        if( true == isEquipped )
            player.UnequipItem( index, false );
        isEquipped = false;
        player.DumpItem( index );
    }

    public void UseCommand() {
        Destroy( gObject );
        player.Action.GetInventoryList().isDialogBoxOn = false;
        player.UseItem( index );
    }

    public void EatCapsuleCommand() {
        if( true == player.InventoryList.CheckItem( ItemManager.ItemCategory.Water ) ) {
            Destroy( gObject );
            player.Action.GetInventoryList().isDialogBoxOn = false;
            player.EatCapsule( index );
        }  
    }

    public void InjectCommand() {
        if( true == GameObject.Find( "Inventory" ).GetComponent<Inventory>().CheckItem( ItemManager.ItemCategory.Water ) ) {
            Destroy( gObject );
            player.Action.GetInventoryList().isDialogBoxOn = false;
            player.InjectItem( index );
        }
    }
    public void EquipCommand() {
        Destroy( gObject );//삭제?
        player.Action.GetInventoryList().isDialogBoxOn = false;
        player.EquipItem( index );
        isEquipped = true;
    }
    public void UnequipCommand() {
        Destroy( gObject );
        player.Action.GetInventoryList().isDialogBoxOn = false;
        player.UnequipItem( index );
        isEquipped = false;
    }
    public void ThrowCommand() {
        Destroy( gObject );
        player.Action.GetInventoryList().isDialogBoxOn = false;
        player.ThrowItem( index );
    }

    public void CancelCommand() {
        Destroy( gObject );
        player.Action.GetInventoryList().isDialogBoxOn = false;
    }
}
