using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public GameObject gameManagerObject;
    private GameManager gameManager;
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
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
        isOpened = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUpAsButton() {
        Debug.Log (isOpened + " " + gameManager.CurrentSituation);
        if ( isOpened && !gameManager.CurrentSituation )
        {
            boardManager.MoveNextRoom (direction);
            gameManager.GenerateMonsters (2);
            gameManager.nextturn ();
        }
    }

}
