using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : Boss {


    public int atkBuffTurn;
    public bool atkBuffOn;
    
    protected override void Start()
    {
        base.Start();
        Debug.Log("교수님 등장");
        level = 1;
        attack = 2; //shld be decided by level and setting file
        defense = 2;
        maxhp = 300;
        hp = maxhp;
        debuffPercent = 0.0f;
        enemyAction = new GunnerAction( this );
        debuff = new Stunned(1);
        player = GameObject.Find("Player").GetComponent<Player>();
        atkBuffTurn = 0;
        atkBuffOn = false;
        delA = 1;
        delD = 1;
    }


    /** \change enemy's Status by level and isHallucinated
     */

    private void OnMouseUpAsButton()
    {
        player.PlayerAction.Attack (this);
        Debug.Log ("플레이어 공격");
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        ItemManager itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        Vector3 tnowPos = transform.position;
        Vector2 nowPos;
        nowPos.x = tnowPos.x;
        nowPos.y = tnowPos.y;
        itemManager.InstantiateItem(ItemManager.ItemCategory.AutoHandgun, nowPos);
    }

}
