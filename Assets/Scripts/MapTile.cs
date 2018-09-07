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
    public List<BoardManager.EnemyType> enemyList;
    public List<ItemManager.ItemCategory> itemList;
    public GameObject gObject;

    public MapTile(MapTile tile)
    {
        x = tile.x;
        y = tile.y;
        roomType = tile.roomType;
        NPCList = new List<BoardManager.NPCType>(tile.NPCList);
        enemyList = new List<BoardManager.EnemyType>(tile.enemyList);
        itemList = new List<ItemManager.ItemCategory>(tile.itemList);
        gObject = tile.gObject;
    }

    public MapTile(int _x, int _y, BoardManager.RoomType _roomType) {
        x = _x;
        y = _y;
        roomType = _roomType;
        NPCList=new List<BoardManager.NPCType>();
        enemyList=new List<BoardManager.EnemyType>();
        itemList=new List<ItemManager.ItemCategory>();
    }

    public void AddEnemy(BoardManager.EnemyType enemy)
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
