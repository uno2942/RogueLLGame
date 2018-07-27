using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC {

	protected string name;
	public float usuability;

	public string Name{
		get{
			return name;
		}
	}

	public virtual void talk (Player player, ItemManager.Label label);
}
