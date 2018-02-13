using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefab : MonoBehaviour {
    
    public ItemManager.Label label;
    //set은 private
    //set은 private

    private void OnMouseUpAsButton()
    {
        Player player = GameObject.Find ("Player").GetComponent<Player> ();
        player.PickItem (label, gameObject);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
