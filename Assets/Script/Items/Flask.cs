using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : Item {

    int hpChange;
    int mpChange;
    int hungerChange;


    public int HPChange
    {
        get
        {
            return hpChange;
        }

        private set
        {
            hpChange = value;
        }
    }
    //set은 private
    public int MPChange
    {
        get
        {
            return mpChange;
        }

        private set
        {
            mpChange = value;
        }
    }
    //set은 private
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

    public Flask( string itemName, string itemProperty = "Null", int HPchange = 0, int MPchange = 0) : base(itemName, itemProperty) {
        this.hpChange = HPchange;
        this.mpChange = MPchange;
        this.hungerChange = hungerChange;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
