using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/**
 * \brief 맵을 구성하는 맵 타일에 해당하는 데이터를 가지는 클래스
 */
public class MapTile {
    private int x;
    private int y;
    public BoardManager.RoomType roomType;
    public List<NPC> NPCList;
    public List<Enemy> enemyList;
    public List<Item> itemList;
    public MapTile(int _x, int _y, BoardManager.RoomType _roomType, List<NPC> _NPCList = default( List<NPC>), List<Enemy> _enemyList=default(List<Enemy>), List<Item> _itemList=default(List<Item>)) {
        x = _x;
        y = _y;
        roomType = _roomType;
        NPCList = _NPCList;
        enemyList = _enemyList;
        itemList = _itemList;
    }

    public void AddEnemy(List<Enemy> enemy)
    {
        enemyList = enemy;
    }

    public void AddNPC(List<NPC> npc)
    {
        NPCList = npc;
    }

    public void AddItem(List<Item> item)
    {
        itemList = item;
    }
}
