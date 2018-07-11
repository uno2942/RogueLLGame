using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    // Use this for initialization
    /** The size of inventory is 12.
     */
    public int size = 12;
    public bool isDialogBoxOn;
    /**
     * Note that *inventoryItemPregab is for background of inventory, not for item prefab*.
     */
    private GameObject inventoryItemPrefab;
    /**
     * It is to distinguish the item contained in inventory.
     */
    private ItemManager.Label [] labelList;
    private GameObject [] inventoryObject;
    /**
     * It contains itemManager gameObject in the scene.
     */
    public ItemManager itemManager;

    public ItemManager.Label [] LabelList
    {
        get
        {
            return labelList;
        }
    }

    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /**
     * \brief It initialise the basic setting of inventory.
     * \details It initiate inventoryObject with empty items and put each objects to appropriate location.
     * To avoid the Monobehavior initializing process which uses start() function, we uses this function and invoke it in player class.(This is unnessesary legacy.)
     * \see Player::Start
     */
    public void Initialize()
    {
        inventoryItemPrefab = GameObject.Find ("PlayerUI").GetComponent<PlayerUI> ().inventoryItemPrefab;
        labelList = new ItemManager.Label [size];
        inventoryObject = new GameObject [size];
        itemManager = GameObject.Find ("ItemManager").GetComponent<ItemManager> ();
        for ( int i = 0; i < 6; i++ )
        {
            inventoryObject [i] = GameObject.Instantiate (inventoryItemPrefab, new Vector2 (-8, i * 1.5f - 4), Quaternion.identity);
            inventoryObject [i].transform.parent = GameObject.Find ("InventoryUI").transform;
            inventoryObject [i + size / 2] = GameObject.Instantiate (inventoryItemPrefab, new Vector2 (8, i * 1.5f - 4), Quaternion.identity);
            inventoryObject [i + size / 2].transform.parent = GameObject.Find ("InventoryUI").transform;
            labelList [i] = labelList [i + 6] = ItemManager.Label.Empty;
        }
    }

        /**
     * When player add an item, it find the location where the item should be and put the item by assigning appropriate sprite and label.
     * The sprite for the label is taken by the function itemManager.LabelToSprite.
     * \param label When player licked item, the gameObject calls this function with label of the item.
     * \see Player::PickItem(ItemManager.Label) and
     * \see Item::OnMouseUpAsButton
     * There is a debug log function.
     */
    public bool AddItem(ItemManager.Label label)
    {
        int location;
        for ( location = 0; location < size; location++ )
        {
            if ( labelList [location] == ItemManager.Label.Empty ) break;
        }

        if ( location < size )
        {
            labelList [location] = label;
            inventoryObject [location].GetComponent<SpriteRenderer> ().sprite = itemManager.LabelToSprite (label);
            inventoryObject [location].GetComponent<InventoryItem> ().Index = location; //남길지 말지 

            if( itemManager.GetItemIdentificationInfo( labelList[ location ] ) )
                inventoryObject[ location ].GetComponentInChildren<UnityEngine.UI.Text>().text = labelList[ location ].ToString();
            return true;
        }
        else
        {
            Debug.Log ("인벤토리가 꽉 찼다.");
            return false;
        }
    }

    public void DeleteItem(int index) {
        inventoryObject[ index ].GetComponent<SpriteRenderer>().sprite = inventoryItemPrefab.GetComponent<SpriteRenderer>().sprite;
        labelList[ index ] = ItemManager.Label.Empty;
        inventoryObject[ index ].GetComponentInChildren<UnityEngine.UI.Text>().text = "Empty";
    }

    public bool CheckItem(  ItemManager.Label _label ) {
        for(int i=0; i<size; i++ ) {
            if( _label == labelList[ i ] )
                return true;
        }
        return false;
    }

    public bool CheckItem(ItemManager.ItemCategory itemCategory ) {
        for( int i = 0; i < size; i++ ) {
            if( itemCategory == ItemManager.LabelToCategory( labelList[ i ] ) )
                return true;
        }
        return false;
    }

    public ItemManager.Label GetLabel( int index ) {
        return LabelList[ index ];
    }

    public int Getindex(ItemManager.Label label ) {
        for( int i = 0; i < size; i++ ) {
            if( label == labelList[ i ] )
                return i;
        }
        return -1;
    }

    public void IdentifyAllTheInventoryItem() {
        for( int i = 0; i < size; i++ ) {
            if( itemManager.GetItemIdentificationInfo( labelList[ i ] ) )
                inventoryObject[ i ].GetComponentInChildren<UnityEngine.UI.Text>().text = labelList[ i ].ToString();
            else if( labelList[ i ] != ItemManager.Label.Empty )
                inventoryObject[ i ].GetComponentInChildren<UnityEngine.UI.Text>().text = "???";
                }
    }
}

