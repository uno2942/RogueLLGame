using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {


    List<itemInformation>[] itemlist = new List<itemInformation>[ 3 ];

    public class itemInformation {
        public string itemName;
        public bool isIdentified = false;

        public itemInformation( string itemNameInput, bool isIdentifiedInput = false ) {
            itemName = itemNameInput;
            isIdentified = isIdentifiedInput;
        }

        /*public itemInformation(Item item) {
            
        }
        */
    }

    // Use this for initialization
    void Start () {
        for( int i = 0; i < 3; i++ )
            itemlist[ i ] = new List<itemInformation>(); //index는 층 수를 의미한다.
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void ItemIdentification(string itemName) {

    }

    /*void ItemIdentification(Item item ) {

    }
    */
}
