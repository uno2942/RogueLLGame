using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * \brief 아이템 프리팹에 붙는 클래스
 */
public class ItemPrefab : MonoBehaviour {
    public ItemManager.Label label;

    /** When the item gameobject is clicked, it is called, and make player pick it.
     */

    public void OnClicked()
    {
        Player player = GameObject.Find ("Player").GetComponent<Player> ();
        player.PlayerAction.PickItem (label, gameObject);
        Destroy( gameObject.GetComponent<Image>() );
        Destroy( gameObject.GetComponent<Button>() );
        gameObject.tag="ItemPickedUp";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
