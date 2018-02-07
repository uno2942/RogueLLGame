using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    private bool isOpened;
    public bool IsOpened
    {
        get
        {
            return isOpened;
        }

        set
        {
            isOpened = value;
        }
    }

    public bool IsRequireKey
    {
        get
        {
            return isRequireKey;
        }

        set
        {
            isRequireKey = value;
        }
    }

    private bool isRequireKey;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
