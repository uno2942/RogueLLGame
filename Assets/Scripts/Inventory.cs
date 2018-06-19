using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    // Use this for initialization

    /** The size of inventory is 12.
     */
    public const int size = 12;
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
            inventoryObject [i] = Instantiate (inventoryItemPrefab, new Vector2 (-8, i * 1.5f - 4), Quaternion.identity);
            inventoryObject [i].transform.parent = GameObject.Find ("PlayerUI").transform;
            inventoryObject [i + size / 2] = Instantiate (inventoryItemPrefab, new Vector2 (8, i * 1.5f - 4), Quaternion.identity);
            inventoryObject [i + size / 2].transform.parent = GameObject.Find ("PlayerUI").transform;
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
    public void AddItem(ItemManager.Label label)
    {
        int location;
        for ( location = 0; location < size; location++ )
        {
            Debug.Log (inventoryObject);
            if ( labelList [location] == ItemManager.Label.Empty ) break;
        }

        if ( location < size )
        {
            labelList [location] = label;
            inventoryObject [location].GetComponent<SpriteRenderer> ().sprite = itemManager.LabelToSprite (label);
        }
        else
        {
            Debug.Log ("아이템이 꽉찼다.");
        }
    }
}
