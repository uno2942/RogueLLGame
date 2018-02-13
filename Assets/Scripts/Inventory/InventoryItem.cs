using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {

    private int index;
    public bool isEquipped;
    private Player player;
    public GameObject[] dialogBox; //0: 무기갑주, 1: 음식, 2: 플라스크
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
        if( false == player.GetInventoryList().isDialogBoxOn ) {
            DialogBox dBox;
            ItemManager.ItemType nowType = ItemManager.LabelToType( player.GetLabel( index ) );
            if( nowType == ItemManager.ItemType.Weapon || nowType == ItemManager.ItemType.Armor ) {
                dBox = ( gObject = Instantiate( dialogBox[ 0 ], new Vector2( 0, 2 ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<WeaponArmorDialogBox>();
                dBox.inventoryItem = this;
                WeaponArmorDialogBox W = dBox as WeaponArmorDialogBox;
                ChangeButtonText( W );

                player.GetInventoryList().isDialogBoxOn = true;

            } else if( nowType == ItemManager.ItemType.Food ) {
                dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0, 2 ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<FoodDialogBox>();
                dBox.inventoryItem = this;
                player.GetInventoryList().isDialogBoxOn = true;
            } else if( nowType == ItemManager.ItemType.Flask ) {
                dBox = ( gObject = Instantiate( dialogBox[ 2 ], new Vector2( 0, 2 ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<FlaskDialogBox>();
                dBox.inventoryItem = this;
                player.GetInventoryList().isDialogBoxOn = true;
            } else return;
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
        player.GetInventoryList().isDialogBoxOn = false;
        if( true == isEquipped )
            player.UnequipItem( index, false );
        isEquipped = false;
        player.DumpItem( index );
    }
    public void EatCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        player.EatItem( index );
    }
    public void DrinkCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        player.DrinkItem( index );
    }
    public void EquipCommand() {
        Destroy( gObject );//삭제?
        player.GetInventoryList().isDialogBoxOn = false;
        player.EquipItem( index );
        isEquipped = true;
    }
    public void UnequipCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        player.UnequipItem( index );
        isEquipped = false;
    }

    public void ThrowCommand() {
        Destroy( gObject );
        player.GetInventoryList().isDialogBoxOn = false;
        player.ThrowItem( index );
    }


}
