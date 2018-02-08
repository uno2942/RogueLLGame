using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : Item {

    protected int hpChange;
    protected int mpChange;
    protected int hungerChange;


    public int HPChange
    {
        get
        {
            return hpChange;
        }
    }
    //set은 private
    public int MPChange
    {
        get
        {
            return mpChange;
        }
    }
    //set은 private
    public int HungerChange
    {
        get
        {
            return hungerChange;
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
