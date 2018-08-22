using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectorCollector : NPC {

    public BoardManager boardmanager;
    public ItemManager.Label injector;

    protected override void Start() {
        name = "InjectorCollector";
        usuability = 100;
        injector = ItemManager.Label.Empty;
        base.Start();
    }

    public override void talk(Player player, ItemManager.Label label)
    {
        if (usuability == 100)
        {
            if (boardmanager.WhichFloor == 5) {
                player.InventoryList.AddItem(ItemManager.Label.BlackKnife);//전설주사기로 바꿔.
                usuability = 0;
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

                player.InventoryList.AddItem(label1);
                player.InventoryList.AddItem(label2);
                player.InventoryList.AddItem(ItemManager.Label.Can);
                player.InventoryList.AddItem(ItemManager.Label.Can);
                player.InventoryList.AddItem(ItemManager.Label.Water);
                player.InventoryList.AddItem(ItemManager.Label.Water);
                usuability = 0;
            }
        }
        else
        {
            usuability = 0;
        }
    }

    //npc 클릭시
    public override void OnClicked()
    {
        if (usuability == 0) //주사 줌
        {
            CantTalkBox dBox = (gObject = Instantiate(dialogBox[0], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<CantTalkBox>();
            dBox.npc = this;
            dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "아아... 훨씬 기분이 좋군요. 감사합니다.";
        }
        else //주사 주기 전
        {
            GivemeBox dBox;
            //ItemManager.ItemType nowType = ItemManager.LabelToType( player.InventoryList.GetLabel( index ) );
            dBox = ( gObject = Instantiate( dialogBox[ 0 ], new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<GivemeBox>();
            player.InventoryList.InjecCommuni = true; // 이제부터 아이템창은 다이얼로그박스와 상호작용합니다.
            player.GetInventoryList().isDialogBoxOn = true;
            dBox.npc = this;
            dBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "주사기... 주사기가 필요해. 혹시 가진 것 없습니까?";

        }
    }

}
