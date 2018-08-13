﻿using System.Collections;
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
public class StatSystem : ComponentSystem {
    struct group {
        public StatECS statECS;
        public ItemECS item;
    }
    public bool CheckCondition(Unit unit, BuffECS.condition condition)
    {
            switch(condition)
            {
                case BuffECS.condition.IsAdrenalined:
                    return unit.IsBuffExist(new Adrenaline(1));
                case BuffECS.condition.IsBleeding:
                    return unit.IsBuffExist(new Bleed(1));
                case BuffECS.condition.IsBurning:
                    return unit.IsBuffExist(new Burn(1));
                case BuffECS.condition.IsCaffeined:
                    return unit.IsBuffExist(new Caffeine(1));
                case BuffECS.condition.isFull:
                    return unit.IsBuffExist(new Full(1));
                case BuffECS.condition.IsHallucinated:
                    return unit.IsBuffExist(new Hallucinated(1));
                case BuffECS.condition.IsHungry:
                    return unit.IsBuffExist(new Hunger());
                case BuffECS.condition.IsMorfined:
                    return unit.IsBuffExist(new Morfin(1));
                case BuffECS.condition.IsPoisoned:
                    return unit.IsBuffExist(new Poison(1));
                case BuffECS.condition.IsRenewaled:
                    return unit.IsBuffExist(new Renewal(1));
                case BuffECS.condition.IsSlept:
                    return unit.IsBuffExist(new Sleep(1));
                case BuffECS.condition.IsStarved:
                    return unit.IsBuffExist(new Starve());
                case BuffECS.condition.IsStunned:
                    return unit.IsBuffExist(new Stunned(1));
                case BuffECS.condition.IsFullHP:
                    return unit.Hp==unit.MaxHp;
                case BuffECS.condition.IsFullMP:
                    Player player=unit as Player;
                    if(player!=null)
                        return player.MaxMp==player.Mp;
                    else
                        return false;
                    break;
                default: //Case of "ToPlayer"
                    return true;
            }
    }
    public void addStat( Unit unit, StatECS.StatList stat, int delta ) {
        Player player;
        switch( stat ) {
        case StatECS.StatList.HP:
            unit.ChangeHp( delta );
            break;
        case StatECS.StatList.MP:
            player = unit as Player;
            player?.ChangeMp( delta );
            break;
        case StatECS.StatList.HUNGER:
            player= unit as Player;
            player?.ChangeHungry( delta );
            break;
        case StatECS.StatList.MAXHP:
            unit.ChangeMaxHp( delta );
            break;
        case StatECS.StatList.ATK:
            unit.ChangeAttack(delta);
            break;
        case StatECS.StatList.DEF:
            unit.ChangeDefense(delta);
            break;
        }
    }

    protected override void OnUpdate() {
        Player player = GameObject.Find( "Player" ).GetComponent<Player>();

        foreach( var e in GetEntities<group>() ) {
            if( e.item.isUse ) {
                if( e.statECS.isUsed ) {
                    Component.Destroy( e.statECS );
                } else {
                    {
                        if(e.item.isThrow==false)
                        {
                            for(int i=0; i<e.statECS.stats.Length; i++)
                                if(CheckCondition(player, e.statECS.condition[i]))
                                    addStat(player, e.statECS.stats[i], e.statECS.deltas[i]);
                        }
                        else
                        {
                             for(int i=0; i<e.statECS.stats.Length; i++)
                                if(e.statECS.isThrown[i]==true)
                                    foreach(var enemy in e.item.enemies)
                                       if(CheckCondition(enemy, e.statECS.condition[i]))
                                          addStat(enemy, e.statECS.stats[i], e.statECS.deltas[i]);
                        }
                    }
                    e.statECS.isUsed = true;
                }
            }
        }
    }
}

public class BuffSystem : ComponentSystem {
	public void addBuff(Unit unit, BuffECS.buffList buff, int count) {

		switch(buff){
		case BuffECS.buffList.ADRENALINE:
			unit.AddBuff(new Adrenaline(count));
			break;
		case BuffECS.buffList.BLEED:
			unit.AddBuff(new Bleed(count));
			break;
		case BuffECS.buffList.BURN:
			unit.AddBuff(new Burn(count));
			break;
		case BuffECS.buffList.CAFFEINE:
			unit.AddBuff(new Caffeine(count));
			break;			
		case BuffECS.buffList.FULL:
			unit.AddBuff(new Full(count));
			break;
		case BuffECS.buffList.HALLUCINATED:
			unit.AddBuff(new Hallucinated(count));
			break;			
		case BuffECS.buffList.HUNGER:
			unit.AddBuff(new Hunger());
			break;
		case BuffECS.buffList.MORFIN:
			unit.AddBuff(new Morfin(count));
			break;			
		case BuffECS.buffList.POISON:
			unit.AddBuff(new Poison(count));
			break;
		case BuffECS.buffList.RENEWAL:
			unit.AddBuff(new Renewal(count));
			break;
		case BuffECS.buffList.SLEEP:
			unit.AddBuff(new Sleep(count));
			break;
		case BuffECS.buffList.STARVE:
			unit.AddBuff(new Starve());
			break;
		case BuffECS.buffList.STUNNED:
			unit.AddBuff(new Stunned(count));
			break;
		case BuffECS.buffList.VITAMINTHROWN:
			unit.AddBuff(new VitaminThrown(count));
			break;
		}
	}
    public bool CheckCondition(Unit unit, BuffECS.condition condition)
    {
            switch(condition)
            {
                case BuffECS.condition.IsAdrenalined:
                    return unit.IsBuffExist(new Adrenaline(1));
                case BuffECS.condition.IsBleeding:
                    return unit.IsBuffExist(new Bleed(1));
                case BuffECS.condition.IsBurning:
                    return unit.IsBuffExist(new Burn(1));
                case BuffECS.condition.IsCaffeined:
                    return unit.IsBuffExist(new Caffeine(1));
                case BuffECS.condition.isFull:
                    return unit.IsBuffExist(new Full(1));
                case BuffECS.condition.IsHallucinated:
                    return unit.IsBuffExist(new Hallucinated(1));
                case BuffECS.condition.IsHungry:
                    return unit.IsBuffExist(new Hunger());
                case BuffECS.condition.IsMorfined:
                    return unit.IsBuffExist(new Morfin(1));
                case BuffECS.condition.IsPoisoned:
                    return unit.IsBuffExist(new Poison(1));
                case BuffECS.condition.IsRenewaled:
                    return unit.IsBuffExist(new Renewal(1));
                case BuffECS.condition.IsSlept:
                    return unit.IsBuffExist(new Sleep(1));
                case BuffECS.condition.IsStarved:
                    return unit.IsBuffExist(new Starve());
                case BuffECS.condition.IsStunned:
                    return unit.IsBuffExist(new Stunned(1));
                case BuffECS.condition.IsFullHP:
                    return unit.Hp==unit.MaxHp;
                case BuffECS.condition.IsFullMP:
                    Player player=unit as Player;
                    if(player!=null)
                        return player.MaxMp==player.Mp;
                    else
                        return false;
                    break;
                default: //Case of "ToPlayer"
                    return true;
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
                    {
                        if(e.item.isThrow==false)
                        {
                            for(int i=0; i<e.buffECS.buff.Length; i++)
                                if(CheckCondition(player, e.buffECS.conditions[i]))
                                    addBuff(player, e.buffECS.buff[i], e.buffECS.count[i]);
                        }
                        else
                        {
                             for(int i=0; i<e.buffECS.buff.Length; i++)
                                if(e.buffECS.isThrown[i]==true)
                                    foreach(var enemy in e.item.enemies)
                                       if(CheckCondition(enemy, e.buffECS.conditions[i]))
                                          addBuff(enemy, e.buffECS.buff[i], e.buffECS.count[i]);
                        }
                    }
                    e.buffECS.isUsed = true;
                }
            }
        }
    }
}