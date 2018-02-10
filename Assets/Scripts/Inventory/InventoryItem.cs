using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {

    private int index;
    private Player player;
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUpAsButton()
    {
        ItemManager.ItemType nowType = ItemManager.LabelToType (player.GetLabel (index));
        if ( nowType == ItemManager.ItemType.Weapon || nowType == ItemManager.ItemType.Armor )
        {

        }
        else if ( nowType == ItemManager.ItemType.Food )
        {

        }
        else if ( nowType == ItemManager.ItemType.Flask )
        {

        }
        else return;
    }
}
