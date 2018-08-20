using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalBox : NPC {

    protected override void Start() {
		name = "MedicalBox";
		usuability = 100;
	}

    public override void talk (Player player){
		if (usuability == 100) {
			player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Burn ) ) ) );
			player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Poison ) ) ) );
			player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Bleed ) ) ) );
			player.ChangeHp (100 - player.Hp);
			usuability = 0;
		}
	}
    public override void OnMouseUpAsButton()
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
