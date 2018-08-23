using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * \brief 문 게임 오브젝트에 붙어서 문의 기능을 관리하는 클래스
 */
public class Door : MonoBehaviour {
    /**
     * I don't know why it is here.
     */
    public GameObject gameManagerObject;
    /**
     * \brief variables to call some functions in manager gameobject.
     * \details gameManger to generate monsters and boardManager to move map.
     * \see OnMouseUpAsButton
     */
    //@{
    private BoardManager boardManager;
    private BoardManager.Direction direction;
    private GameManager gameManager;
    //@}
    private bool isOpened;
    /**
 * \brief Check whether the door is opend.
 */
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
    /**
 * \brief bool value whether the door requires key.
 */
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
    /**
     * put proper gameobeject to boardManager and gameManager variables
     */
    void Start() {
        boardManager = GameObject.Find( "BoardManager" ).GetComponent<BoardManager>();
        gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
        isOpened = true;
    }

    // Update is called once per frame
    void Update() {

    }
    /**
     * When the door is clicked, this function is called, and if the door can be opened, it moves player and generate monsters by calling functions in gameManager and boardManager.
     */
    private void OnMouseUpAsButton() {
        Debug.Log( isOpened + " " + gameManager.CurrentSituation );
        if( isOpened && !gameManager.CurrentSituation ) {
            switch( tag ) {
            case "EastDoor": direction = BoardManager.Direction.Right; break;
            case "WestDoor": direction = BoardManager.Direction.Left; break;
            case "NorthDoor": direction = BoardManager.Direction.UpSide; break;
            case "SouthDoor": direction = BoardManager.Direction.DownSide; break;
            default: break;
            }

            boardManager.MoveNextRoom( direction );
            gameManager.EndPlayerTurn( Unit.Action.Move);
            gameManager.GenerateItems( boardManager.XPos, boardManager.YPos );
            gameManager.GenerateMonsters( boardManager.XPos, boardManager.YPos );
            gameManager.GenerateNPCs( boardManager.XPos, boardManager.YPos );
        }
    }

}
