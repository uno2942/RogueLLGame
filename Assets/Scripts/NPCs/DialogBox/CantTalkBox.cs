using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CantTalkBox : MonoBehaviour {

	protected Button[] buttons;
	public NPCPrefab npc;
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
			if (buttons [i].name == "OK")
				buttons [i].onClick.AddListener (OKCommand);
		}

	}
	private void OKCommand() {
	}
}
