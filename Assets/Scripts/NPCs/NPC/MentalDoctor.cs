using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentalDoctor : NPC {

	public MentalDoctor(){
		name = "MentalDoctor";
		usuability = 100;
	}

	public void talk (Player player){
		if (usuability == 100) {
			player.DeleteBuff (player.Bufflist.Find (x => x.GetType ().Equals (typeof(Hallucinated)))); 
			player.ChangeMp (100 - player.Mp);
			usuability = 0;
		}
	}
}
