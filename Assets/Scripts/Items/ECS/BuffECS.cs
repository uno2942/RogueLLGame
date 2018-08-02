using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffECS : MonoBehaviour {
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
	public buffList buff;
	public bool isUsed;
	public int count;

	
}
