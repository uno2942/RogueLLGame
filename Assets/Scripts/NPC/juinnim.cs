using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juinnim : MonoBehaviour {

    public bool identify = false;
    public bool ismet = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUpAsButton() {
        ismet = true;
        GameObject.Find( "InventoryUI" ).GetComponentInChildren<UnityEngine.UI.Text>().enabled = true;

    }
}
