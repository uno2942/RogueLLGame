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


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
