using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineMaster : NPC {

    public ItemManager.Label pill;

    protected override void Start() {
		name = "MedicineMaster";
		usuability = 100;
        pill = ItemManager.Label.Empty;
        base.Start();
	}

    public override void talk( Player player ) {
        usuability = 0;
        CantTalkBox dBox;
        player.GetInventoryList().isDialogBoxOn = true;
        dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CantTalkBox>();
        dBox.npc = this;
        MessageMaker messageMaker = GameObject.Find( "Logger" ).GetComponent<MessageMaker>();
        GameObject.Find( "ItemManager" ).GetComponent<ItemManager>().ItemIdentify( pill );
        dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "이 알약은" + messageMaker.Name(pill) +  "입니다.";
    }

    public override void OnClicked() {

        if( usuability == 100)
        {
            SelectBox dBox;
            dBox = ( gObject = Instantiate( dialogBox[ 0 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<SelectBox>();
            player.InventoryList.MedicineCommuni = true; // 이제부터 아이템창은 다이얼로그박스와 상호작용합니다.
            player.GetInventoryList().isDialogBoxOn = true;
            dBox.npc = this;
            dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "알약 성분의 분석이 가능한 분석기가 있습니다.";
        }
        else 
        {
            CantTalkBox dBox;
            player.GetInventoryList().isDialogBoxOn = true;
            dBox = (gObject = Instantiate(dialogBox[1], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<CantTalkBox>();
            dBox.npc = this;
            dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "분석기의 전원이 꺼져 있습니다.";
        }
    }
}
