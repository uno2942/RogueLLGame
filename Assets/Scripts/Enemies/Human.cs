using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Enemy
{
    private int[] hpDB;
    private int[] atkDB;
    private int[] defDB;
    private int[] dropDB;
    private int[] nDropDB;
    /** 
     * There is a debug code.
     * incomplete:: shld be read settings file
     */
    protected override void Start()
    {
        base.Start();
        Debug.Log( "사람 나타남" );
        hpDB = new int[ 6 ] { 31, 37, 64, 72, 106, 119 };
        atkDB = new int[ 6 ] { 2, 2, 4, 5, 7, 9 };
        defDB = new int[ 6 ] { 1, 1, 3, 4, 6, 7 };
        dropDB = new int[6] { 10, 10, 15, 15, 20, 20 };
        nDropDB = new int[6] { 20, 20, 30, 30, 40, 40 };

        level = boardManager.WhichFloor;
        attack = atkDB[ level ]; //shld be decided by level and setting file
        defense = defDB[ level ];
        maxhp = hpDB[ level ];
        hp = maxhp;
        debuffPercent = 0.0f;
        enemyAction = new EnemyAction( this );
        debuff = null;
        player = GameObject.Find( "Player" ).GetComponent<Player>();
    }

    public override void ChangeStatus( bool isHallucinated ) {
        base.ChangeStatus( isHallucinated );
    }

    private void OnDestroy()
    {
        int per;
        if(player.InventoryList.CheckItem(ItemManager.Label.AdrenalineDrug) || player.InventoryList.CheckItem(ItemManager.Label.MorfinDrug)) //약이 있는경우
        {
            per = dropDB[level];
        }
        else
        {
            if (player.isHallucinated) per = 100;
            else per = nDropDB[level];
        }

        if (per > UnityEngine.Random.Range(0, 100))
        {
            Debug.Log("주사기 줍니다");
            ItemManager itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
            Array values = Enum.GetValues(typeof(ItemManager.ItemCategory));
            ItemManager.ItemCategory randomBar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));

            while (ItemManager.CategoryToType(randomBar) != ItemManager.ItemType.Injector || randomBar == ItemManager.ItemCategory.RingerSolution)
            {
                randomBar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
            }
            Vector3 tnowPos = transform.position;
            Vector2 nowPos;
            nowPos.x = tnowPos.x;
            nowPos.y = tnowPos.y;

            itemManager.InstantiateItem(randomBar, nowPos);
        }
                
    }

    /** \ incomplete: shld access at room
     * 
     */
}