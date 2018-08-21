using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleDespenser : NPC {

	public BoardManager boardmanager;

	protected override void Start(){
		name = "CapsuleDespenser";
		usuability = 100;
        boardmanager = GameObject.Find( "BoardManager" ).GetComponent<BoardManager>();  
        base.Start();
	}

	public override void talk (Player player){
		if (usuability == 100) {

            player.GetInventoryList().isDialogBoxOn = true;
            CantTalkBox dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CantTalkBox>();
            dBox.npc = this;
            dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "[알약 공급이 완료되었습니다.]";

            GiveCapsule();
            
			usuability = 50;
		} else if (usuability == 50) {

            if (UnityEngine.Random.Range(0, 100) >= 50)
            {
                player.GetInventoryList().isDialogBoxOn = true;
                CantTalkBox dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CantTalkBox>();
                dBox.npc = this;
                dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "[알약 공급이 완료되었습니다.]";

                GiveCapsule();
            }
            else
            {
                player.GetInventoryList().isDialogBoxOn = true;
                CantTalkBox dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CantTalkBox>();
                dBox.npc = this;
                dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "[위험, 기계 과부하!]";

                Boom();
            }
		}
	}
    public override void OnMouseUpAsButton()
    {
        if( player.GetInventoryList().isDialogBoxOn == false ) {
            if( usuability == 100 ) {

                TalkingBox dBox = ( gObject = Instantiate( dialogBox[ 0 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<TalkingBox>();
                player.GetInventoryList().isDialogBoxOn = true;
                dBox.npc = this;
                //            GameObject.FindWithTag<BoxText> GetComponentInChildren<UnityEngine.UI.Text>().text = "[알약 공급 성공 확률: 100%. 알약을 받으시겠습니까?]";
                dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "[알약 공급 성공 확률: 100%. 알약을 받으시겠습니까?]";
            } else {
                TalkingBox dBox = ( gObject = Instantiate( dialogBox[ 0 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<TalkingBox>();
                player.GetInventoryList().isDialogBoxOn = true;
                dBox.npc = this;
                dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "[알약 공급 성공 확률: 50%. 기계 과부하 위험성 존재. 알약을 받으시겠습니까?]";
            }
        }
    }

    public void GiveCapsule()
    {
        Array values = Enum.GetValues( typeof( ItemManager.ItemCategory ) );
        ItemManager.ItemCategory randomBar = (ItemManager.ItemCategory) values.GetValue( UnityEngine.Random.Range( 0, values.Length ) );

        while( ItemManager.CategoryToType( randomBar ) != ItemManager.ItemType.Capsule || randomBar == ItemManager.ItemCategory.CureAll ) {
            randomBar = (ItemManager.ItemCategory) values.GetValue( UnityEngine.Random.Range( 0, values.Length ) );
        }

        //ItemManager.Label label = ItemManager.Label.CaffeinCapsule1;
        ItemManager.Label label = ItemManager.CategoryToLabel( randomBar, boardmanager.WhichFloor );

        player.InventoryList.AddItem( label );
    }

    public void Boom()
    {
        player.ChangeHp( -30 );
        usuability = 0;
        Destroy( gameObject );
    }

}
