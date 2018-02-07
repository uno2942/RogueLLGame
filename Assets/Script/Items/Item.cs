using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    
    private string property;
    private new string name;

    public string Property
    {
        get
        {
            return property;
        }

        private set
        {
            property = value;
        }
    }
    //set은 private
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
    //set은 private

    public Item( string itemName, string itemProperty = "Null" ) { name = itemName; property = itemProperty; }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
