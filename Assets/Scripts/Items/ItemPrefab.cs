using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * \brief 아이템 프리팹에 붙는 클래스
 */
public class ItemPrefab : MonoBehaviour {

    protected new string name;//Why it is deleted?
    /** Each item has its label
     */
    public ItemManager.Label label;
    //set은 private
    /** Each item has name
     */
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


    /** When the item gameobject is clicked, it is called, and make player pick it.
     */
    private void OnMouseUpAsButton()
    {
        Player player = GameObject.Find ("Player").GetComponent<Player> ();
        player.Action.PickItem (label, gameObject);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
