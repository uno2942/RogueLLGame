using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogBox : MonoBehaviour {

    protected Button[] buttons;
    public InventoryItem inventoryItem;
	// Use this for initialization
	void Start () {
        buttons = gameObject.GetComponentsInChildren<Button>();
        Init();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    protected virtual void Init() {

    }
    protected void DumpCommand() {
        inventoryItem.DumpCommand();
    }

    protected void CancelCommand() {
        inventoryItem.CancelCommand();
    }
}
