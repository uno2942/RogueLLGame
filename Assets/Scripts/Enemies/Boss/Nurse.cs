using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : Boss {

    public int atkBuffTurn;
    public bool atkBuffOn;
    protected override void Start()
    {
        Debug.Log("간호사 등장");
        base.Start ();
        level = 1;
        defaultA = 6; //shld be decided by level and setting file
        defaultD = 1;
        maxhp = 450;
        hp = maxhp;
        debuffPercent = 0.0f;
        enemyAction = new NurseAction (this);
        debuff = new Bleed (3);
        player = GameObject.Find ("Player").GetComponent<Player> ();
        atkBuffTurn = 0;
        atkBuffOn = false;
        delA = 4;
        delD = 1;
    }


    /** \change enemy's Status by level and isHallucinated
     */

    private void OnMouseUpAsButton()
    {
        player.PlayerAction.Attack (this);
        Debug.Log ("플레이어 공격");
    }

}
