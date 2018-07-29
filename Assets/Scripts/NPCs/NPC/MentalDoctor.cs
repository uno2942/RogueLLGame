using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentalDoctor : NPC {

	public MentalDoctor(){
		name = "MentalDoctor";
		usuability = 100;
	}

	public void talk (Player player){
		if (usuability == 100) {
			player.DeleteBuff (player.Bufflist.Find (x => x.GetType ().Equals (typeof(Hallucinated)))); 
			player.ChangeMp (100 - player.Mp);
			usuability = 0;
		}
	}

    void OnMouseUpAsButton()
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
