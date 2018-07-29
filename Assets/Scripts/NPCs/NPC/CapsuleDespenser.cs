using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleDespenser : NPC {

	public BoardManager boardmanager;

	public CapsuleDespenser(){
		name = "CapsuleDespenser";
		usuability = 100;
	}

	public void talk (Player player){
		if (usuability == 100) {
			Array values = Enum.GetValues(typeof(ItemManager.ItemCategory));                   
            ItemManager.ItemCategory randomBar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));

            while (ItemManager.CategoryToType(randomBar) != ItemManager.ItemType.Capsule || randomBar == ItemManager.ItemCategory.CureAll) {
                randomBar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
            }

            ItemManager.Label label = ItemManager.CategoryToLabel(randomBar, boardmanager.WhichFloor);

            player.InventoryList.AddItem(label);
			usuability = 50;
		} else if (usuability == 50) {

            if (UnityEngine.Random.Range(0, 1) >= 0.5)
            {
                Array values = Enum.GetValues(typeof(ItemManager.ItemCategory));
                ItemManager.ItemCategory randomBar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));

                while (ItemManager.CategoryToType(randomBar) != ItemManager.ItemType.Capsule || randomBar == ItemManager.ItemCategory.CureAll)
                {
                    randomBar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                }

                ItemManager.Label label = ItemManager.CategoryToLabel(randomBar, boardmanager.WhichFloor);

                player.InventoryList.AddItem(label);
            }
            else
            {
                player.ChangeHp(-30);
                usuability = 0;
            }
		}
	}
    void OnMouseUpAsButton()
    {
        if (usuability == 0)
        {
            CantTalkBox dBox = (gObject = Instantiate(dialogBox[0], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<CantTalkBox>();
            dBox.npc = this;
        }
        else
        {
            TalkingBox dBox = (gObject = Instantiate(dialogBox[0], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<TalkingBox>();
            dBox.npc = this;
        }
    }
}
