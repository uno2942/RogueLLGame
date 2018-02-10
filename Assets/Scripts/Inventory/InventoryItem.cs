using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {

    private int index;
    private bool isEquipped;
    private Player player;
    public GameObject[] dialogBox; //0: 무기갑주, 1: 음식, 2: 플라스크
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

    void OnMouseUpAsButton()
    {
        DialogBox dBox;
        ItemManager.ItemType nowType = ItemManager.LabelToType (player.GetLabel (index));
        if ( nowType == ItemManager.ItemType.Weapon || nowType == ItemManager.ItemType.Armor )
        {
            dBox = Instantiate( dialogBox[ 0 ], new Vector2( 0, 2 ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ).GetComponent<WeaponArmorDialogBox>();
            dBox.index = index;
            WeaponArmorDialogBox W = dBox as WeaponArmorDialogBox;
            W.isEquipped = isEquipped;
            
        }
        else if ( nowType == ItemManager.ItemType.Food )
        {
            dBox = Instantiate( dialogBox[ 1 ], new Vector2( 0, 2 ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ).GetComponent<FoodDialogBox>();
            dBox.index = index;
        }
        else if ( nowType == ItemManager.ItemType.Flask )
        {
            dBox = Instantiate( dialogBox[ 2 ], new Vector2( 0, 2 ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ).GetComponent<FlaskDialogBox>();
            dBox.index = index;
        }
        else return;
    }
}
