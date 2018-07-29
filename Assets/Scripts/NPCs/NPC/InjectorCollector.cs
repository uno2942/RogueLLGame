using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectorCollector : NPC {

    public BoardManager boardmanager;

    public InjectorCollector()
    {
        name = "CapsuleDespenser";
        usuability = 100;
    }

    public void talk(Player player)
    {
        if (usuability == 100)
        {
            Array values = Enum.GetValues(typeof(ItemManager.ItemCategory));
            ItemManager.ItemCategory randomBar1 = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
            ItemManager.ItemCategory randomBar2 = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));

            while (ItemManager.CategoryToType(randomBar1) != ItemManager.ItemType.Capsule || randomBar1 == ItemManager.ItemCategory.CureAll
                ||ItemManager.CategoryToType(randomBar2) != ItemManager.ItemType.Capsule || randomBar2 == ItemManager.ItemCategory.CureAll
                ||randomBar1==randomBar2
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
        else
        {
            usuability = 0;
        }
    }
    void OnMouseUpAsButton()
    {
        if (usuability == 0)
        {
            CantTalkBox dBox = (gObject = Instantiate(dialogBox[0], new Vector2(0 + GameObject.Find("PlayerUI").transform.position.x, 2 + GameObject.Find("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find("PlayerUI").transform)).GetComponent<CantTalkBox>();
            dBox.npc = this;
        }
        else
        {
            player.InventoryList.InjecCommuni = true;
        }
    }

}
