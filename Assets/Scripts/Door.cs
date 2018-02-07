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
    
    private BoardManager boardManager;
    public BoardManager.Direction direction;

    // Use this for initialization
    void Start () {
        boardManager = GameObject.Find( "BoardManager" ).GetComponent<BoardManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUpAsButton() {
        //if( isOpened )
            boardManager.MoveNextRoom(direction);
    }

}
