using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingBox: MonoBehaviour {

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
		for(int i=0; i<buttons.Length; i++ ) {
			if( buttons[ i ].name == "Use" )
				buttons[ i ].onClick.AddListener( UseCommand );
			else if( buttons[ i ].name == "No" )
				buttons[ i ].onClick.AddListener( NoCommand );
		}

	}
	private void UseCommand() {
		npc.UseCommand ();
	}

	private void NoCommand() {
	}
}
