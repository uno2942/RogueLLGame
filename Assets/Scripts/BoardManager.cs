using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public const int verticalMovement = 10;
    public const int horizontalMovement = 18;

    public enum Direction { Right=0, UpSide=1, Left=2, DownSide=3};

    public GameObject doorPrefab;
    public Camera gameCamera;
    public Player playerobejct;

    private int xPos, yPos;
    private int whichFloor;

    public Vector2 NowPos()
    {
        return new Vector2 (xPos * horizontalMovement, yPos * verticalMovement);
    }
    public int XPos
    {
        get
        {
            return xPos;
        }
    }

    public int YPos
    {
        get
        {
            return yPos;
        }
    }

    public int WhichFloor
    {
        get
        {
            return whichFloor;
        }
    }

    // Use this for initialization
    void Start() {


        GameObject doorObject = Instantiate( doorPrefab, new Vector2( 7, 0 ), Quaternion.identity ) as GameObject;
        Door door = doorObject.GetComponent<Door>();
        door.direction = Direction.Right;

        doorObject = Instantiate( doorPrefab, new Vector2( -7, 0 ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.Left;

        doorObject = Instantiate( doorPrefab, new Vector2( 0, 5 ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.UpSide;

        doorObject = Instantiate( doorPrefab, new Vector2( 0, -5 ), Quaternion.identity ) as GameObject;
        door = doorObject.GetComponent<Door>();
        door.direction = Direction.DownSide;
        playerobejct = GameObject.Find( "Player" ).GetComponent<Player>();

        xPos = yPos = 0;
        whichFloor = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveNextRoom(Direction direction) {
        //if(map is valid)
        {
            switch(direction) {
            case Direction.Right:
                gameCamera.transform.position += new Vector3Int( horizontalMovement, 0, 0 );
                playerobejct.transform.position += new Vector3Int( horizontalMovement, 0, 0 );
                xPos++;
                break;
            case Direction.Left:
                gameCamera.transform.position -= new Vector3Int( horizontalMovement, 0, 0 );
                playerobejct.transform.position -= new Vector3Int( horizontalMovement, 0, 0 );
                xPos--;
                break;
            case Direction.UpSide:
                gameCamera.transform.position += new Vector3Int( 0, verticalMovement, 0 );
                playerobejct.transform.position += new Vector3Int( 0, verticalMovement, 0 );
                yPos++;
                break;
             case Direction.DownSide:
                gameCamera.transform.position -= new Vector3Int(0, verticalMovement, 0 );
                playerobejct.transform.position -= new Vector3Int( 0, verticalMovement, 0 );
                yPos--;
                break;
            }

        }
    }
}
