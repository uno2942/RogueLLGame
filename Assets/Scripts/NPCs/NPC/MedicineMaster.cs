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

        dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "오, 그 알약은" + messageMaker.Name(pill) +  "이라네.";
    }

    public override void OnClicked()
    {
        if (usuability == 0)
        {
            CantTalkBox dBox;
            player.GetInventoryList().isDialogBoxOn = true;
            dBox = (gObject = Instantiate(dialogBox[1], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<CantTalkBox>();
            dBox.npc = this;
            dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "더 이상은 알려줄 수 없으니 가 보시게나.";
        }
        else
        {
            SelectBox dBox;
            dBox = (gObject = Instantiate(dialogBox[0], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<SelectBox>();
            player.InventoryList.MedicineCommuni = true; // 이제부터 아이템창은 다이얼로그박스와 상호작용합니다.
            player.GetInventoryList().isDialogBoxOn = true;
            dBox.npc = this;
            dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "안녕하신가. 알약을 보여주면 뭔지 알려주겠네.";
        }
    }
}
