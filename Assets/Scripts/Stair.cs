using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * \brief 계단을 관리하는 클래스
 */
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
    /**
     * 계단이 클릭되었을 때 카드가 있는지 확인하고, 있을 경우 카드를 사용할 것인지 상자를 띄운다.
     */
    void OnMouseUpAsButton() {
        player = GameObject.Find( "Player" ).GetComponent<Player>();
        if( player.InventoryList.CheckItem( ItemManager.Label.BlackCard ) ) {
            dBox = ( gObject = Instantiate( cardDialogBox, new Vector2( 0 + GameObject.Find( "PlayerUI" ).transform.position.x, 2 + GameObject.Find( "PlayerUI" ).transform.position.y ), Quaternion.identity, GameObject.Find( "PlayerUI" ).transform ) ).GetComponent<CardDialogBox>();

            player.Action.GetInventoryList().isDialogBoxOn = true;
        }
    }
    /**
     * 플레이어가 계단 클릭 후 카드를 사용하기로 하였을 때 실행되는 함수. 다음 층으로 간다.
     * @todo 다음 층으로 가는 것이 구현되어 있지 않다.
     */
    public void GotoNextFloor() {
        Destroy( gObject );
        player.Action.GetInventoryList().isDialogBoxOn = false;
        player.InventoryList.DeleteItem( player.InventoryList.Getindex( ItemManager.Label.BlackCard ));
        GameObject.Find( "GameManager" ).GetComponent<GameManager>().EndPlayerTurn();
            
    }
    /**
     * 플레이어가 계단 클릭 후 카드를 사용하지 않기로 하였을 때 실행되는 함수
     */
    public void Cancle() {
        Destroy( gObject );
        player.Action.GetInventoryList().isDialogBoxOn = false;
    }
}
