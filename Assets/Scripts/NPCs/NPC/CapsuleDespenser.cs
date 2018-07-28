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

	public void talk (Player player, ItemManager.Label label){
		if (usuability == 100) {
			
			Array values = Enum.GetValues(typeof(ItemManager.Label));
			//if((ItemManager.Label randomBar = (ItemManager.Label)values.GetValue(UnityEngine.Random.Range(0, values.Length))==notInCapsuleCategory);



			//if( player.InventoryList.AddItem( label ) == true ) {
			//	player.InventoryList.IdentifyAllTheInventoryItem();
			//}
			usuability = 50;
		} else if (usuability == 50) {

			usuability = 0;
		}
	}
    void OnMouseUpAsButton()
    {
        TalkingBox dBox;
        if (usuability == 0)
        {
            dBox = (gObject = Instantiate(dialogBox[0], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<CantTalkBox>();
            dBox.npc = this;
        }
        else
        {
            dBox = (gObject = Instantiate(dialogBox[0], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<TalkingBox>();
            dBox.npc = this;
        }
    }
}
