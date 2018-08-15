using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GivemeBox : TalkingBox
{
    public InventoryItem inventoryItem;

    protected override void Init()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name == "준다")
                buttons[i].onClick.AddListener(UseCommand);
            else if (buttons[i].name == "안준다")
                buttons[i].onClick.AddListener(NoCommand);
        }
    }
    public override void UseCommand()
    {
        Destroy(npc.gObject);
        inventoryItem.DumpCommand();
        npc.talk(npc.player);
    }

    private void NoCommand()
    {
        Destroy(npc.gObject);
    }
}
