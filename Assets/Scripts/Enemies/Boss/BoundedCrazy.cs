using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedCrazy : Enemy {

    private void Start()
    {
        Debug.Log("구속된 미치광이가 나타났습니다. 마주하고 있자니 정신이 이상해지는 듯 합니다.");
        level = 1;
        attack = 6; //shld be decided by level and setting file
        defense = 0;
        maxhp = 80;
        hp = maxhp;
        debuffPercent = 0.0f;
        action = new BoundedCrazyAction( this );
        player = GameObject.Find( "Player" ).GetComponent<Player>();
        debuff = null;
    }


    private void OnMouseUpAsButton() {
        player.Action.Attack( this );
        Debug.Log( "플레이어 공격" );
    }

    /** \change enemy's Status by level and isHallucinated
     */
    public override void changeStatus(bool isHallucinated)
    {
        //read setting file and change
        if (isHallucinated == true)
        {
            attack = 22;
            defense = 0;
            debuffPercent = 0.0f;
            
        }
        else
        {
            attack = 6;
            defense = 0;
            debuffPercent = 0.0f;
        }
        
    }


}
