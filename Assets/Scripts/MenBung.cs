using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenBung : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseUpAsButton () {
        Debug.Log ("MAGA");
        Player player = GameObject.Find ("Player").GetComponent<Player> ();
        player.ChangeHungry (-90);
	}
}
