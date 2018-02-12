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
    

    void Start () {
        player = GameObject.Find ("Player").GetComponent<Player> ();
        isEquipped = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUpAsButton() {
        
        DialogBox dBox;
        ItemManager.ItemType nowType = ItemManager.LabelToType (player.GetLabel (index));
        if ( nowType == ItemManager.ItemType.Weapon || nowType == ItemManager.ItemType.Armor )
        {
            dBox = (gObject = Instantiate( dialogBox[ 0 ], new Vector2( 0, 2 ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform )).GetComponent<WeaponArmorDialogBox>();
            dBox.inventoryItem = this;
            WeaponArmorDialogBox W = dBox as WeaponArmorDialogBox;
            
        }
        else if ( nowType == ItemManager.ItemType.Food )
        {
            dBox = (gObject=Instantiate( dialogBox[ 1 ], new Vector2( 0, 2 ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform )).GetComponent<FoodDialogBox>();
            dBox.inventoryItem = this;
        }
        else if ( nowType == ItemManager.ItemType.Flask )
        {
            dBox = (gObject=Instantiate( dialogBox[ 2 ], new Vector2( 0, 2 ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform )).GetComponent<FlaskDialogBox>();
            dBox.inventoryItem = this;
        }
        else return;
    }

    public void DumpCommand() {
        Debug.Log( "asedf" );
        Destroy(gObject);
        player.DumpItem( index );
        isEquipped = false;
    }

    public void EatCommand() {
        Destroy( gObject );
        player.EatItem( index );
    }

    public void DrinkCommand() {
        Destroy( gObject );
        player.DrinkItem( index );
    }

    public void ThrowCommand() {
        Destroy( gObject );
        player.ThrowItem( index );
    }

    public void EquipCommand() {
        Destroy( gObject );//삭제?
        player.EquipItem( index );
        isEquipped = true;
    }

    public void UnequipCommand() {
        Destroy( gObject );
        player.UnequipItem( index );
        isEquipped = false;
    }
}
