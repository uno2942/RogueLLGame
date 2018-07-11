using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour {

    public GameObject cardDialogBox;
    private GameObject gObject;
    Player player;
    DialogBox dBox;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseUpAsButton() {
        player = GameObject.Find( "Player" ).GetComponent<Player>();
        if( player.InventoryList.CheckItem( ItemManager.Label.BlackCard ) ) {
            dBox = ( gObject = Instantiate( cardDialogBox, new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CardDialogBox>();

            player.Action.GetInventoryList().isDialogBoxOn = true;
        }
    }
    public void GotoNextFloor() {
        Destroy( gObject );
        player.Action.GetInventoryList().isDialogBoxOn = false;
        player.InventoryList.DeleteItem( player.InventoryList.Getindex( ItemManager.Label.BlackCard ));
        GameObject.Find( "GameManager" ).GetComponent<GameManager>().EndPlayerTurn();
            
    }

    public void Cancle() {
        Destroy( gObject );
        player.Action.GetInventoryList().isDialogBoxOn = false;
    }
}
