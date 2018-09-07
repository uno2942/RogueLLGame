using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectorCollector : NPC {

    public BoardManager boardmanager;
    public GameManager gamemanager;
    public ItemManager.Label injector;
    private ItemManager itemmanager;

    protected override void Start() {
        name = "InjectorCollector";
        usuability = 100;
        injector = ItemManager.Label.Empty;
        boardmanager = GameObject.Find( "BoardManager" ).GetComponent<BoardManager>();
        gamemanager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
        itemmanager = GameObject.Find( "ItemManager" ).GetComponent<ItemManager>();
        base.Start();
    }

    public override void talk(Player player)
    {
        if (usuability == 100)
        {
            if (boardmanager.WhichFloor == 5) {
                player.InventoryList.AddItem(ItemManager.Label.BlackKnife);//전설주사기로 바꿔.
                usuability = 0;

                player.InventoryList.InjecCommuni = false;

                CantTalkBox dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CantTalkBox>();
                dBox.npc = this;
                dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "감사합니다. 여기 제가 가지고 있던 비상식량과 알약을 가져가세요.";
                player.GetInventoryList().isDialogBoxOn = false; //다이얼로그 끝난 정보 저장
            }
            else
            {
                Array values = Enum.GetValues(typeof(ItemManager.ItemCategory));
                ItemManager.ItemCategory randomBar1 = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                ItemManager.ItemCategory randomBar2 = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));

                while (ItemManager.CategoryToType(randomBar1) != ItemManager.ItemType.Capsule || randomBar1 == ItemManager.ItemCategory.CureAll
                    || ItemManager.CategoryToType(randomBar2) != ItemManager.ItemType.Capsule || randomBar2 == ItemManager.ItemCategory.CureAll
                    || randomBar1 == randomBar2
                    )
                {
                    randomBar1 = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                    randomBar2 = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                }

                ItemManager.Label label1 = ItemManager.CategoryToLabel(randomBar1, boardmanager.WhichFloor);
                ItemManager.Label label2 = ItemManager.CategoryToLabel(randomBar2, boardmanager.WhichFloor);

                /*
                player.PlayerAction.PickItem( label1 );
                player.PlayerAction.PickItem( label2 );
                player.PlayerAction.PickItem( ItemManager.Label.Can );
                player.PlayerAction.PickItem( ItemManager.Label.Can );
                player.PlayerAction.PickItem( ItemManager.Label.Water );
                player.PlayerAction.PickItem( ItemManager.Label.Water );*/
                //아이템 포지션 설정.
                Vector2 nowPos = new Vector2( boardmanager.XPos * BoardManager.horizontalMovement, boardmanager.YPos * BoardManager.verticalMovement );
                Vector2 [] GenPos = new Vector2 [6];
                for ( var i = 0; i < 6; i++ )
                    GenPos [i] = new Vector2 (-5 + 2*i, 0);

                itemmanager.InstantiateItem( randomBar1, GenPos[ 0 ] + nowPos);
                itemmanager.InstantiateItem( randomBar2, GenPos[ 1 ] + nowPos);
                itemmanager.InstantiateItem( ItemManager.ItemCategory.Can , GenPos[ 2 ] + nowPos);
                itemmanager.InstantiateItem( ItemManager.ItemCategory.Can, GenPos[ 3 ] + nowPos);
                itemmanager.InstantiateItem( ItemManager.ItemCategory.Water, GenPos[ 4 ] + nowPos);
                itemmanager.InstantiateItem( ItemManager.ItemCategory.Water, GenPos[ 5 ] + nowPos);


                usuability = 0;

                player.InventoryList.InjecCommuni = false;

                CantTalkBox dBox = ( gObject = Instantiate( dialogBox[ 1 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CantTalkBox>();
                dBox.npc = this;
                dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "감사합니다. 여기 제가 가지고 있던 비상식량과 알약을 가져가세요.";
                player.GetInventoryList().isDialogBoxOn = false; //다이얼로그 끝난 정보 저장

            }
        }
        else
        {
            Debug.Log( "InjectorCollector error: talk shld not work when usuablility = 0" );
            usuability = 0;
        }
    }

    //npc 클릭시
    public override void OnClicked()
    {
        if (usuability == 0) //주사 줌
        {
            CantTalkBox dBox = (gObject = Instantiate(dialogBox[1], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<CantTalkBox>();
            dBox.npc = this;
            dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "훨씬 기분이 좋군요. 감사합니다.";
        }
        else //주사 주기 전
        {
            GivemeBox dBox;
            //ItemManager.ItemType nowType = ItemManager.LabelToType( player.InventoryList.GetLabel( index ) );
            dBox = ( gObject = Instantiate( dialogBox[ 0 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<GivemeBox>();
            player.InventoryList.InjecCommuni = true; // 이제부터 아이템창은 다이얼로그박스와 상호작용합니다.
            player.GetInventoryList().isDialogBoxOn = true;
            dBox.npc = this;
            dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "으으... 목이 마릅니다. 음료수 없나요?";
            //건네주기 로 버튼 변경
        }
    }

}
