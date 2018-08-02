using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ItemSystem : ComponentSystem {
    struct group {
        public ItemECS item;
    }

    protected override void OnUpdate() {
        Player player = GameObject.Find( "Player" ).GetComponent<Player>();

        foreach( var e in GetEntities<group>() ) {
            var item = e.item;
            if( item.isUse && item.gameObject.GetComponents<Component>().Length == 3 )
                GameObject.Destroy( item.gameObject );
        }
    }
}
public class HPSystem : ComponentSystem {
    struct group {
        public HPECS hp;
        public ItemECS item;
    }

    protected override void OnUpdate() {
        Player player = GameObject.Find( "Player" ).GetComponent<Player>();

        foreach( var e in GetEntities<group>() ) {
            if( e.item.isUse ) {
                if( e.hp.isUsed ) {
                    Component.Destroy( e.hp );
                } else {
                    player.ChangeHp(e.hp.deltaHP);
                    e.hp.isUsed = true;
                }
            }
        }
    }
}

public class BuffSystem : ComponentSystem {
	public void addBuff(Player player, BuffECS.buffList buff, int count){
		switch(buff){
		case BuffECS.buffList.ADRENALINE:
			player.AddBuff(new Adrenaline(count));
			break;
		case BuffECS.buffList.BLEED:
			player.AddBuff(new Bleed(count));
			break;
		case BuffECS.buffList.BURN:
			player.AddBuff(new Burn(count));
			break;
		case BuffECS.buffList.CAFFEINE:
			player.AddBuff(new Caffeine(count));
			break;			
		case BuffECS.buffList.FULL:
			player.AddBuff(new Full(count));
			break;
		case BuffECS.buffList.HALLUCINATED:
			player.AddBuff(new Hallucinated(count));
			break;			
		case BuffECS.buffList.HUNGER:
			player.AddBuff(new Hunger());
			break;
		case BuffECS.buffList.MORFIN:
			player.AddBuff(new Morfin(count));
			break;			
		case BuffECS.buffList.POISON:
			player.AddBuff(new Poison(count));
			break;
		case BuffECS.buffList.RENEWAL:
			player.AddBuff(new Renewal(count));
			break;
		case BuffECS.buffList.SLEEP:
			player.AddBuff(new Sleep(count));
			break;
		case BuffECS.buffList.STARVE:
			player.AddBuff(new Starve());
			break;
		case BuffECS.buffList.STUNNED:
			player.AddBuff(new Stunned(count));
			break;
		case BuffECS.buffList.VITAMINTHROWN:
			player.AddBuff(new VitaminThrown(count));
			break;
		}
	}

    struct group {
        public BuffECS buffECS;
        public ItemECS item;
    }

    protected override void OnUpdate() {
        Player player = GameObject.Find( "Player" ).GetComponent<Player>();

        foreach( var e in GetEntities<group>() ) {
            if( e.item.isUse ) {
                if( e.buffECS.isUsed ) {
                    Component.Destroy( e.buffECS );
                } else {
					addBuff(player, e.buffECS.buff, e.buffECS.count);
                    e.buffECS.isUsed = true;
                }
            }
        }
    }
}