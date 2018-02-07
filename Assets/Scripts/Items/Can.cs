using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : Item {

    public int hungerChange;

    public int HungerChange
    {
        get
        {
            return hungerChange;
        }

        private set
        {
            hungerChange = value;
        }
    }
    //set은 private

    public Can( string itemName, string itemProperty = "Null", int hungerChange = 0 ) : base(itemName, itemProperty) {
        this.hungerChange = hungerChange;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
