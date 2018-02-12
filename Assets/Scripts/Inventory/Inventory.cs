using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    // Use this for initialization
    public int size = 12;
    private GameObject inventoryItemPrefab;
    private ItemManager.Label [] labelList;
    private GameObject [] inventoryObject;
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
    public void Initialize()
    {
        inventoryItemPrefab = GameObject.Find ("PlayerUI").GetComponent<PlayerUI> ().inventoryItemPrefab;
        labelList = new ItemManager.Label [size];
        inventoryObject = new GameObject [size];
        itemManager = GameObject.Find ("ItemManager").GetComponent<ItemManager> ();
        for ( int i = 0; i < 6; i++ )
        {
            inventoryObject [i] = Instantiate (inventoryItemPrefab, new Vector2 (-8, i * 1.5f - 4), Quaternion.identity);
            inventoryObject [i].transform.parent = GameObject.Find ("InventoryUI").transform;
            inventoryObject [i + size / 2] = Instantiate (inventoryItemPrefab, new Vector2 (8, i * 1.5f - 4), Quaternion.identity);
            inventoryObject [i + size / 2].transform.parent = GameObject.Find ("InventoryUI").transform;
            labelList [i] = labelList [i + 6] = ItemManager.Label.Empty;
        }
    }
    
    public void AddItem(ItemManager.Label label)
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
        }
        else
        {
            Debug.Log ("아이템이 꽉찼다.");
        }
    }

    public void DeleteItem(int index) {
        Destroy( inventoryObject[ index ].GetComponent<SpriteRenderer>().sprite );
        labelList[ index ] = ItemManager.Label.Empty;
    }
}

