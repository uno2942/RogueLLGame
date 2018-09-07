using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
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
}*/

public class GivemeBox : MonoBehaviour {
    public InventoryItem inventoryItem;
    protected Button[] buttons;
    public InjectorCollector npc;
    public ItemManager.Label injector;

    // Use this for initialization
    void Start() {
        buttons = gameObject.GetComponentsInChildren<Button>();
        injector = ItemManager.Label.Empty;
        Init();
    }

    protected void Init() {
        for( int i = 0; i < buttons.Length; i++ ) {
            if( buttons[ i ].name == "Giveme" )
                buttons[ i ].onClick.AddListener( UseCommand );
            else if( buttons[ i ].name == "Cancel" )
                buttons[ i ].onClick.AddListener( NoCommand );
        }
    }
    public void UseCommand() {
        
        if(injector == ItemManager.Label.Empty) { //아이템 안들어감
            this.GetComponentInChildren<UnityEngine.UI.Text>().text = "음료수.... 음료수를 주세요!";
        } else { //아이템 들어감
            Debug.Log(injector.ToString() + "를 주었다.");
            npc.player.DumpItem( npc.player.InventoryList.Getindex( injector ) ); // 아이템 버리고
            npc.player.InventoryList.InjecCommuni = false; //대화 끝남 추가하고
            Destroy( npc.gObject ); //이 박스 터트리고         
            npc.talk( npc.player ); //다음 작업 수행

        }
        //inventoryItem.DumpCommand();
        //npc.extalk( npc.player, npc.player.InventoryList.GetLabel( inventoryItem.Index ) );
    }

    private void NoCommand() {
        npc.player.InventoryList.InjecCommuni = false;
        npc.player.GetInventoryList().isDialogBoxOn = false; //다이얼로그 끝난 정보 저장
        Destroy( npc.gObject );
    }
}
