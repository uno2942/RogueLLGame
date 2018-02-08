using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    
    protected new string name;
    public ItemManager.Label label;
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

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
