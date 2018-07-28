using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineMaster : NPC {

	public MedicineMaster(){
		name = "MedicineMaster";
		usuability = 100;
	}

	public override void talk(Player player, ItemManager.Label label){
		player.InventoryList.itemManager.ItemIdentify (label);
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
