using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon {
    public override int AttackPower
    {
        get
        {
            return attackPower;
        }
    }
    // Use this for initialization
    void Start () {
        attackPower = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
