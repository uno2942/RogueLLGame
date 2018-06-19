using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    protected new string name;
    /** Each item has its label
     */
    public ItemManager.Label label;
    //set은 private
    /** Each item has name
     */
    public string Name
    {
        get
        {
            return name;
        }

        private set
        {
            name = value;
        }
    }

    /** When the item gameobject is clicked, it is called, and make player pick it.
     */
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
