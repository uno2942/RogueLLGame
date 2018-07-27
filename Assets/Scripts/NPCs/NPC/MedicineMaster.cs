﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineMaster : NPC {

	public MedicineMaster(){
		name = "MedicineMaster";
		usuability = 100;
	}

	public override void talk(Player player, ItemManager.Label label){
		player.InventoryList.itemManager.ItemIdentify (label);
	}
}
