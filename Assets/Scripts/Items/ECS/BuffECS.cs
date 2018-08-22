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
        IsDefenseless,
		IsFull,
        IsGiddiness,
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
        Defenseless,
        FULL,
        Giddiness,
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
	public bool[] negate;
	public buffList[] buff;
	public int[] count;
	public bool isUsed;

}
