using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleDespenser : NPC {

	public BoardManager boardmanager;

	public CapsuleDespenser(){
		name = "CapsuleDespenser";
		usuability = 100;
	}

	public void talk (Player player){
		if (usuability == 100) {
			
			Array values = Enum.GetValues(typeof(ItemManager.Label));
			//if((ItemManager.Label randomBar = (ItemManager.Label)values.GetValue(Random.range(values.Length))==notInCapsuleCategory);



			//if( player.InventoryList.AddItem( label ) == true ) {
			//	player.InventoryList.IdentifyAllTheInventoryItem();
			//}
			usuability = 50;
		} else if (usuability == 50) {

			usuability = 0;
		}
	}

}
