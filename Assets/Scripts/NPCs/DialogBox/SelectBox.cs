using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBox : MonoBehaviour
{
    public InventoryItem inventoryItem;
    protected Button[] buttons;
    public MedicineMaster npc;

    // Use this for initialization
    void Start()
    {
        buttons = gameObject.GetComponentsInChildren<Button>();
        Init();
    }

    protected  void Init()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name == "선택")
                buttons[i].onClick.AddListener(UseCommand);
            else if (buttons[i].name == "취소")
                buttons[i].onClick.AddListener(NoCommand);
        }
    }
    public  void UseCommand()
    {
        Destroy(npc.gObject);
        inventoryItem.DumpCommand();
        npc.extalk(npc.player, npc.player.InventoryList.GetLabel( inventoryItem.Index));
    }

    private void NoCommand()
    {
        Destroy(npc.gObject);
    }
}
