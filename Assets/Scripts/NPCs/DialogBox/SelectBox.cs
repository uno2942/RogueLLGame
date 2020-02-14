using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBox : MonoBehaviour
{
    public InventoryItem inventoryItem;
    protected Button[] buttons;
    public MedicineMaster npc;
    public ItemManager.Label pill;

    // Use this for initialization
    void Start()
    {
        buttons = gameObject.GetComponentsInChildren<Button>();
        pill = ItemManager.Label.Empty;
        Init();
    }

    protected  void Init()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].name == "Giveme" )
                buttons[i].onClick.AddListener(UseCommand);
            else if (buttons[i].name == "Cancel")
                buttons[i].onClick.AddListener(NoCommand);
        }
    }
    public  void UseCommand()
    {
        if( pill == ItemManager.Label.Empty ) { //아이템 안들어감
            this.GetComponentInChildren<UnityEngine.UI.Text>().text = "알약을 넣어야 작동할 것 같습니다.";
        } else { //아이템 들어감
            Debug.Log( pill.ToString() + "를 보여주었다." );
            npc.player.InventoryList.itemManager.ItemIdentify( pill ); // 아이템 감정하고
            npc.player.InventoryList.MedicineCommuni = false; //대화 끝남 추가하고
            Destroy( npc.gObject ); //이 박스 터트리고         
            GameObject.Find( "MedicineMaster" ).GetComponent<MedicineMaster>().pill = pill;
            npc.talk( npc.player ); //다음 작업 수행
            
            
        }             
        
    }

    private void NoCommand()
    {
        npc.player.InventoryList.MedicineCommuni = false;
        npc.player.GetInventoryList().isDialogBoxOn = false; //다이얼로그 끝난 정보 저장
        Destroy( npc.gObject );
    }
}
