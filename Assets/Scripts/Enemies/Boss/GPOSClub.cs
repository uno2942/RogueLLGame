using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPOSClub : Boss
{
    private BoardManager boardmanager;
    private int bosses;

    public int Bosses
    {
        get
        {
            return bosses;
        }
    }

    protected override void Start()
    {
        base.Start ();

        Debug.Log ("'P'대 힘내라 동아리 등장");
        level = 0;
        defaultA = attack = 3; //shld be decided by level and setting file
        defaultD = defense = 5;
        maxhp = 140;
        hp = maxhp;
        debuffPercent = 0.0f;
        enemyAction = new GPOSClubAction (this);
        player = GameObject.Find ("Player").GetComponent<Player> ();
        debuff = null;
        bosses = 0;
        delA = 3;
        delD = 7;
    }


    /** \change enemy's Status by level and isHallucinated
     */

    private void OnMouseUpAsButton()
    {
        player.PlayerAction.Attack (this);
        Debug.Log ("플레이어 공격");
    }

    public void Check()
    {
        bosses = 0;
        var currenttile = boardmanager.CurrentTile;
        var curtransform = currenttile.gObject.transform;
        for ( var i = 0; i < curtransform.childCount; i++ )
        {
            if ( curtransform.GetChild (i).gameObject.tag == "Boss" )
            {
                bosses += 1;
            }
        }

        switch ( bosses )
        {
            case 1:
                defaultA = 7;
                defaultD = 9;
                break;
            case 2:
                defaultA = 6;
                defaultD = 8;
                break;
            case 3:
                defaultA = 5;
                defaultD = 7;
                break;
            case 4:
                defaultA = 4;
                defaultD = 6;
                break;
            case 5:
                defaultA = 3;
                defaultD = 5;
                break;
            default: break;
        }
    }

}