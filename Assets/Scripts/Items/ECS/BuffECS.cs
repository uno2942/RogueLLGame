using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffECS : MonoBehaviour {
	public enum condition{
		Default,
		IsFullHP,
		IsFullMP,
		IsAdrenalined,
		IsBleeding,
		IsBurning,
		IsCaffeined,
		isFull,
		IsHallucinated,
		IsHungry,
		IsMorfined,
		IsPoisoned,
		IsRenewaled,
		IsSlept,
		IsStarved,
		IsStunned,
		ToPlayer
	};
	public enum buffList{
		ADRENALINE,
		BLEED,
		BURN,
		CAFFEINE,
		FULL,
		HALLUCINATED,
		HUNGER,
		MORFIN,
		POISON,
		RENEWAL,
		SLEEP,
		STARVE,
		STUNNED,
		VITAMINTHROWN
	};
	public bool[] isThrown;
	public condition[] conditions;
	public buffList[] buff;
	public int[] count;
	public bool isUsed;

	
}
