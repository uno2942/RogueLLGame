using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    
    public ItemManager.Label label;
    //set은 private
    //set은 private

    private void OnMouseUpAsButton()
    {
        Debug.Log ("안녕");
        Player player = GameObject.Find ("Player").GetComponent<Player> ();
        player.PickItem (label);
        Destroy (gameObject);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
