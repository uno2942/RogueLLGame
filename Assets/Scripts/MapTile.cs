using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/**
 * \brief 맵을 구성하는 맵 타일에 해당하는 데이터를 가지는 클래스
 */
public class MapTile {
    public int x;
    public int y;
    public BoardManager.RoomType roomType;
    public List<BoardManager.NPCType> NPCList;
    public List<Enemy> enemyList;
    public List<ItemManager.ItemCategory> itemList;
    public MapTile(int _x, int _y, BoardManager.RoomType _roomType, List<BoardManager.NPCType> _NPCList = default( List<BoardManager.NPCType>), List<Enemy> _enemyList=default(List<Enemy>), List<ItemManager.ItemCategory> _itemList=default(List<ItemManager.ItemCategory>)) {
        x = _x;
        y = _y;
        roomType = _roomType;
        NPCList = _NPCList;
        enemyList = _enemyList;
        itemList = _itemList;
    }

    public void AddEnemy(Enemy enemy)
    {
        enemyList.Add(enemy);
    }

    public void AddNPC(BoardManager.NPCType npc)
    {
        NPCList.Add(npc);
    }

    public void AddItem(ItemManager.ItemCategory item)
    {
        itemList.Add(item);
    }
}
