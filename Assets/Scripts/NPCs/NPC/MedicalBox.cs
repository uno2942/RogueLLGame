using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalBox : NPC {

    protected override void Start() {
		name = "MedicalBox";
		usuability = 100;
        base.Start();
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
        if( player.GetInventoryList().isDialogBoxOn == false ) {
            if( usuability == 0 ) {
                player.GetInventoryList().isDialogBoxOn = true;
                CantTalkBox dBox;
                dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CantTalkBox>();
                dBox.npc = this;
                dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "구급상자의 내용물이 비었습니다.";
                dBox.GetComponentsInChildren<UnityEngine.UI.Button>()[ 0 ].GetComponentInChildren<UnityEngine.UI.Text>().text = "닫기";
            } else {
                player.GetInventoryList().isDialogBoxOn = true;
                TalkingBox dBox;
                dBox = ( gObject = Instantiate( dialogBox[ 0 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<TalkingBox>();
                dBox.npc = this;
                dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = " 각종 응급치료용 약품이 들어있는 구급상자입니다.";
                dBox.GetComponentsInChildren<UnityEngine.UI.Button>()[ 0 ].GetComponentInChildren<UnityEngine.UI.Text>().text = "치료";
            }
        }
    }
}
