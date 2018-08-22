using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentalDoctor : NPC {

    protected override void Start() {
		name = "MentalDoctor";
		usuability = 100;
        base.Start();
    }

	public override void talk (Player player){
		if (usuability == 100) {
			player.DeleteBuff (player.Bufflist.Find (x => x.GetType ().Equals (typeof(Hallucinated)))); 
			player.ChangeMp (100 - player.Mp);
			usuability = 0;
		}
	}

    public override void OnClicked()
    {
        if( player.GetInventoryList().isDialogBoxOn == false ) {
            if( usuability == 0 ) {
                player.GetInventoryList().isDialogBoxOn = true;
                CantTalkBox dBox;
                dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CantTalkBox>();
                dBox.npc = this;
                dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "이 정도면 충분할 것입니다.";
                dBox.GetComponentsInChildren<UnityEngine.UI.Button>()[ 0 ].GetComponentInChildren<UnityEngine.UI.Text>().text = "닫기";
            } else {
                player.GetInventoryList().isDialogBoxOn = true;
                TalkingBox dBox;
                dBox = ( gObject = Instantiate( dialogBox[ 0 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<TalkingBox>();
                dBox.npc = this;
                dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "많이 힘드십니까? 제가 도움을 드리겠습니다.";
                dBox.GetComponentsInChildren<UnityEngine.UI.Button>()[ 0 ].GetComponentInChildren<UnityEngine.UI.Text>().text = "치료";
            }
        }
    }
}
