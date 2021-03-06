﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingBox: MonoBehaviour {

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
		for(int i=0; i<buttons.Length; i++ ) {
			if( buttons[ i ].name == "Get" )
				buttons[ i ].onClick.AddListener( UseCommand );
			else if( buttons[ i ].name == "Cancel" )
				buttons[ i ].onClick.AddListener( NoCommand );
		}

	}
	public virtual void UseCommand() {
        Destroy(npc.gObject);
        npc.player.GetInventoryList().isDialogBoxOn = false;
        npc.talk(npc.player);
	}

	private void NoCommand() {
        npc.player.GetInventoryList().isDialogBoxOn = false;
        Destroy(npc.gObject);
    }
}
