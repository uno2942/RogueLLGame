using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * \brief 화면에 보는 NPC와 상호작용하는 클래스.
 */

public class NPCPrefab : MonoBehaviour {

	private NPC npc; 
	private Player player;
	public GameObject[] dialogBox;
	GameObject gObject;

	// Use this for initialization
	void Start () {
		player = GameObject.Find( "Player" ).GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void OnMouseUpAsButton() {
		TalkingBox dBox;
		if (npc.usuability == 0) {
			dBox = (gObject = Instantiate (dialogBox [0], new Vector2 (0 + GameObject.Find ("PlayerUI").transform.position.x, 2 + GameObject.Find ("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find ("PlayerUI").transform)).GetComponent<CantTalkBox> ();
			dBox.npc = this;
		} else {
			dBox = (gObject = Instantiate (dialogBox [0], new Vector2 (0 + GameObject.Find ("PlayerUI").transform.position.x, 2 + GameObject.Find ("PlayerUI").transform.position.y), Quaternion.identity, GameObject.Find ("PlayerUI").transform)).GetComponent<TalkingBox> ();
			dBox.npc = this;
		}
	}
		
	public void UseCommand(){
		Destroy( gObject );
		npc.talk (player);
	}
}
