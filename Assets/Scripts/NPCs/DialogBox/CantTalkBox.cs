using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CantTalkBox : MonoBehaviour {

	protected Button[] buttons;
	public NPC npc;
	// Use this for initialization
	void Start () {
		buttons = gameObject.GetComponentsInChildren<Button>();
		Init();
	}

	// Update is called once per frame
	void Update () {

	}
	protected virtual void Init() {
		for (int i = 0; i < buttons.Length; i++) {
			if (buttons [i].name == "Close")
				buttons [i].onClick.AddListener (CloseCommand);
		}

	}
	private void CloseCommand()
    {
        npc.player.GetInventoryList().isDialogBoxOn = false;

        Destroy(npc.gObject);
    }
}
