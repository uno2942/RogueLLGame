using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * \brief 아이템 프리팹에 붙는 클래스
 */
public class ItemPrefab : MonoBehaviour {
    public ItemManager.Label label;

    /** When the item gameobject is clicked, it is called, and make player pick it.
     */
    private void OnMouseUpAsButton()
    {
        Player player = GameObject.Find ("Player").GetComponent<Player> ();
        player.PlayerAction.PickItem (label);
        Destroy( gameObject.GetComponent<SpriteRenderer>() );
        Destroy( gameObject.GetComponent<BoxCollider2D>() );
        gameObject.tag="ItemPickedUp";
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
