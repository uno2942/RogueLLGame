using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineMaster : NPC {

    protected override void Start() {
		name = "MedicineMaster";
		usuability = 100;
	}

	public void extalk(Player player, ItemManager.Label label){
		player.InventoryList.itemManager.ItemIdentify (label);
	}

    public override void OnClicked()
    {
        if (usuability == 0)
        {
            CantTalkBox dBox;
            dBox = (gObject = Instantiate(dialogBox[0], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<CantTalkBox>();
            dBox.npc = this;
        }
        else
        {
            TalkingBox dBox;
            dBox = (gObject = Instantiate(dialogBox[0], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<TalkingBox>();
            dBox.npc = this;
        }
    }
}
