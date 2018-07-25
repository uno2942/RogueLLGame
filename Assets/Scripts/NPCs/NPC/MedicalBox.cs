using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalBox : NPC {
	
	public MedicalBox(){
		name = "MedicalBox";
		usuability = 100;
	}

	public void talk (Player player){
		if (usuability == 100) {
			player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Burn ) ) ) );
			player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Poison ) ) ) );
			player.DeleteBuff( player.Bufflist.Find( x => x.GetType().Equals( typeof( Bleed ) ) ) );
			player.ChangeHp (100 - player.Hp);
			usuability = 0;
		}
	}
}
