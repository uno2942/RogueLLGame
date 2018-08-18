﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
/**
 * \brief 맵 파일을 파싱하는 클래스
 */
public class MapGenerator
{

    /**
     * @todo 첫 번째 열은 버려야 함.(데이터에 대한 설명을 담고 있음.)
     */

    public ItemManager itemmanager;

    public List<List<MapTile>> Maps;

    private GameObject BossPrefab;
    private GameObject NormalRoomPrefab;
    private GameObject HallPrefab;
    private GameObject PStartPrefab;
    private GameObject EquipRoomPrefab;
    private GameObject RestRoomPrefab;
    private GameObject LockedRoomPrefab;
    private GameObject DrugRoomPrefab;

    public void parse(ref List<List<MapTile>> mapTiles)
    {
        BossPrefab = (GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Prefabs/BossRoom.prefab", typeof(GameObject));
        NormalRoomPrefab = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Prefabs/Ground.prefab", typeof( GameObject ) );
        HallPrefab = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Prefabs/Hall.prefab", typeof( GameObject ) );
        PStartPrefab = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Prefabs/Ground.prefab", typeof( GameObject ) );
        EquipRoomPrefab = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Prefabs/EquipRoom.prefab", typeof( GameObject ) );
        RestRoomPrefab = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Prefabs/RestRoom.prefab", typeof( GameObject ) );
        LockedRoomPrefab = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Prefabs/LockedRoom.prefab", typeof( GameObject ) );
        DrugRoomPrefab = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Prefabs/DrugRoom.prefab", typeof( GameObject ) );

        Maps =new List<List<MapTile>>();
        int i;
        for (i = 0; i < 10; i++)
        {
            Maps.Add(new List<MapTile>());
            var mapData = File.ReadAllLines(Application.dataPath + @"\Resources\" + "Map" + i + ".txt");
            foreach (string str in mapData)
            {
                var temp = str.Split('\t');
                if(temp[0]=="Coordinate")
                    continue;
                Maps[i].Add(new MapTile(int.Parse(temp[0]), int.Parse(temp[1]), ConvertLetterToMapType(temp[2])));
            }
        }

        for (i = 0; i < 6; i++)
        {
            mapTiles.Add(Maps[UnityEngine.Random.Range(0, 10)]);
            mapTiles[i] = Generate(ShuffleList(mapTiles[i]), i + 1);
        }
    }

    private BoardManager.RoomType ConvertLetterToMapType(string str)
    {
        switch (str)
        {
            case "N": return BoardManager.RoomType.NormalRoom;
            case "H": return BoardManager.RoomType.Hall;
            case "B": return BoardManager.RoomType.BossRoom;
            case "D": return BoardManager.RoomType.DrugRoom;
            case "L": return BoardManager.RoomType.LockedRoom;
            case "R": return BoardManager.RoomType.RestRoom;
            case "Q": return BoardManager.RoomType.Equipment;
            case "P": return BoardManager.RoomType.PlayerStart;
            case "E": return BoardManager.RoomType.End;
        }
        return BoardManager.RoomType.Empty;
    }
    public void GenMapObject(List<MapTile> floor) {
        foreach(MapTile tile in floor)
        {
            GameObject tileobj = new GameObject();
            Vector2 position = new Vector2(14 * tile.x, 10 * tile.y);

            switch (tile.roomType) {
				case BoardManager.RoomType.BossRoom:
					tileobj = GameObject.Instantiate( BossPrefab, position, Quaternion.identity);
					tileobj.transform.localScale = new Vector3(6.23f, 4.47f, 1);
                    break;
                case BoardManager.RoomType.NormalRoom:
                    tileobj = GameObject.Instantiate( NormalRoomPrefab, position, Quaternion.identity);
                    break;
                case BoardManager.RoomType.Hall:
					tileobj = GameObject.Instantiate( HallPrefab, position, Quaternion.identity);
					tileobj.transform.localScale = new Vector3(5.1f, 5.5f, 1);
                    break;
				case BoardManager.RoomType.DrugRoom:
					tileobj = GameObject.Instantiate( DrugRoomPrefab, position, Quaternion.identity);
					tileobj.transform.localScale = new Vector3(5.4f, 5.15f, 1);
                    break;
                case BoardManager.RoomType.LockedRoom:
					tileobj = GameObject.Instantiate( LockedRoomPrefab, position, Quaternion.identity);
					tileobj.transform.localScale = new Vector3(4.89f, 5.68f, 1);
                    break;
                case BoardManager.RoomType.RestRoom:
					tileobj = GameObject.Instantiate( RestRoomPrefab, position, Quaternion.identity);
					tileobj.transform.localScale = new Vector3(7.23f, 3.86f, 1);
                    break;
                case BoardManager.RoomType.Equipment:
					tileobj = GameObject.Instantiate( EquipRoomPrefab, position, Quaternion.identity);
					tileobj.transform.localScale = new Vector3(4.91f, 5.6f, 1);
                    break;
                case BoardManager.RoomType.PlayerStart:
                    tileobj = GameObject.Instantiate( PStartPrefab, position, Quaternion.identity);
                    break;
            }
        }
    }

    private List<MapTile> Generate(List<MapTile> map, int floor)
    {
        Dictionary<string, int> RoomCounts = new Dictionary<string, int>();
        RoomCounts.Add("L", 1);
        RoomCounts.Add("N1", 0);
        RoomCounts.Add("N2", 0);
        RoomCounts.Add("N3", 0);

        Dictionary<string, int> itemCounts = new Dictionary<string,int>();
        Dictionary<string, int> capsuleCounts = new Dictionary<string, int>();
        
        itemCounts.Add("Equip", 2);
        itemCounts.Add("Capsule", 4);
        itemCounts.Add("Injector", 2);
        itemCounts.Add("Can", 1);
        itemCounts.Add("Water", 5);
        itemCounts.Add("Medicine", 3);
        itemCounts.Add("Bandage", 3);

        foreach (MapTile tile in map)
        {
            if (tile.roomType == BoardManager.RoomType.LockedRoom)
                RoomCounts["N1"]++;
        }

        int p = 0;
        foreach (MapTile tile in map)
        {
            p++;
            switch (tile.roomType)
            {
                case BoardManager.RoomType.BossRoom:
                    switch (floor)
                    {
                        case 1:
                            tile.AddEnemy(BoardManager.EnemyType.BoundedCrazy);
                            break;
                        case 2:
                            tile.AddEnemy(BoardManager.EnemyType.Gunner);
                            break;
                        case 3:
                            tile.AddEnemy(BoardManager.EnemyType.Nurse);
                            break;
                        case 4:
                            tile.AddEnemy(BoardManager.EnemyType.AngryDog);
                            break;
                        case 5:
                            tile.AddEnemy(BoardManager.EnemyType.AngryDog);//환자들 만들어야 해.
                            break;
                        case 6:
                            tile.AddEnemy(BoardManager.EnemyType.HospitalDirector);
                            break;
                    }
                    break;
                case BoardManager.RoomType.NormalRoom:
                    switch (Ntype(RoomCounts["N1"], RoomCounts["N2"], RoomCounts["N3"]))
                    {
                        case "1_NPC":
                            tile.AddNPC(randomNPC());
                            break;
                        case "2_Enemy":
                            tile.AddEnemy(randomEnemy());
                            tile.AddEnemy(randomEnemy());
                            break;
                        case "3_Enemy":
                            tile.AddEnemy(randomEnemy());
                            tile.AddEnemy(randomEnemy());
                            tile.AddEnemy(randomEnemy());
                            break;
                        case "1_Item":
                            tile.AddItem(randomItem(itemCounts));
                            break;
                        case "2_Item":
                            tile.AddItem(randomItem(itemCounts));
                            tile.AddItem(randomItem(itemCounts));
                            break;
                        case "1_Enemy":
                            tile.AddEnemy(randomEnemy());
                            break;
                        case "1_WK+1_Item":
                            tile.AddItem(randomItem(itemCounts));
                            tile.AddItem(ItemManager.ItemCategory.WhiteCard);
                            break;
                        case "1_Can+3_Water":
                            tile.AddItem(ItemManager.ItemCategory.Can);
                            tile.AddItem(ItemManager.ItemCategory.Water);
                            tile.AddItem(ItemManager.ItemCategory.Water);
                            tile.AddItem(ItemManager.ItemCategory.Water);
                            break;
                        case "1_Enemy+1_YK":
                            tile.AddEnemy(randomEnemy());
                            tile.AddItem(ItemManager.ItemCategory.YellowCard);
                            break;
                    }
                    break;
                case BoardManager.RoomType.Hall:
                    switch (Htype())
                    {
                        case "Nothing":
                            break;
                        case "1_Enemy":
                            tile.AddEnemy(randomEnemy());
                            break;
                        case "2_Enemy":
                            tile.AddEnemy(randomEnemy());
                            tile.AddEnemy(randomEnemy());
                            break;
                        case "1_Item":
                            tile.AddItem(randomItem(itemCounts));
                            break;
                    }
                    break;
                case BoardManager.RoomType.DrugRoom:
                case BoardManager.RoomType.RestRoom:
                    if (floor == 5)
                    {
                        tile.AddNPC(BoardManager.NPCType.DrugVecder);
                        tile.AddNPC(BoardManager.NPCType.InjectorCollector);
                    }
                    else
                    {
                        switch (Rtype())
                        {
                            case "CanNPC+1_NPC":
                                tile.AddNPC(BoardManager.NPCType.DrugVecder);
                                tile.AddNPC(randomNPC());
                                break;
                            case "CanNPC+2_NPC":
                                tile.AddNPC(BoardManager.NPCType.DrugVecder);
                                tile.AddNPC(randomNPC());
                                tile.AddNPC(randomNPC());
                                break;
                        }
                    }
                    break;
                case BoardManager.RoomType.LockedRoom:
                    switch (Ltype(RoomCounts["L"]))
                    {
                        case "1_NPC":
                            tile.AddNPC(randomNPC());
                            break;
                        case "2_Item":
                            tile.AddItem(randomItem(itemCounts));
                            tile.AddItem(randomItem(itemCounts));
                            break;
                        case "1_Human+1_Ringer":
                            tile.AddEnemy(BoardManager.EnemyType.Human);
                            tile.AddItem(ItemManager.ItemCategory.RingerSolution);
                            break;
                        case "1_CureAll+1_Water":
                            tile.AddItem(ItemManager.ItemCategory.CureAll);
                            tile.AddItem(ItemManager.ItemCategory.Water);
                            break;
                    }
                    break;
                case BoardManager.RoomType.Equipment:
                    if (floor == 1)
                    {
                        Array values = Enum.GetValues(typeof(ItemManager.ItemCategory));
                        ItemManager.ItemCategory randombar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                        Debug.Log(randombar);
                        while (ItemManager.CategoryToType(randombar) != ItemManager.ItemType.Weapon)
                        {
                            randombar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                        }
                        tile.AddItem(randombar);
                    }
                    else
                    {
                        Array values = Enum.GetValues(typeof(ItemManager.ItemCategory));
                        ItemManager.ItemCategory randombar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                        while (ItemManager.CategoryToType(randombar) != ItemManager.ItemType.Weapon
                            && ItemManager.CategoryToType(randombar) != ItemManager.ItemType.Armor)
                        {
                            randombar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                        }
                        tile.AddItem(randombar);

                    }
                    break;
                case BoardManager.RoomType.PlayerStart:
                    break;
                default: break;
            }
        }

        return map;
    }

    private string Ntype(int N1, int N2, int N3)
    {
        int percent = UnityEngine.Random.Range(0, 130);

        while (
            (100 <= percent && percent < 110 && N1 == 0) ||
            (110 <= percent && percent < 120 && N2 == 0) ||
            (120 <= percent && percent < 130 && N3 == 0)
            )
        {
            percent = UnityEngine.Random.Range(0, 130);
        }

        string type;
        if (0 <= percent && percent < 10)
            type = "1_NPC";
        else if (10 <= percent && percent < 25)
            type = "2_Enemy";
        else if (25 <= percent && percent < 40)
            type = "3_Enemy";
        else if (40 <= percent && percent < 55)
            type = "1_Item";
        else if (55 <= percent && percent < 70)
            type = "2_Item";
        else if (70 <= percent && percent < 100)
            type = "1_Enemy";
        else if (100 <= percent && percent < 110)
            type = "1_WK+1_Item";
        else if (110 <= percent && percent < 120)
            type = "1_Can+3_Water";
        else
            type = "1_Enemy+1_YK";

        return type;
    }

    private string Htype()
    {
        int percent = UnityEngine.Random.Range(0, 100);

        string type;
        if (0 <= percent && percent < 50)
            type = "Nothing";
        else if (50 <= percent && percent < 70)
            type = "1_Enemy";
        else if (70 <= percent && percent < 90)
            type = "2_Enemy";
        else
            type = "1_Item";

        return type;
    }

    private string Rtype()
    {
        int percent = UnityEngine.Random.Range(0, 100);

        string type;
        if (0 <= percent && percent < 70)
            type = "CapNPC+1_NPC";
        else
            type = "CapNPC+2_NPC";

        return type;
    }

    private string Ltype(int L)
    {
        int percent = UnityEngine.Random.Range(0, 110);

        while (100 <= percent && percent < 110 && L == 0)
        {
            percent = UnityEngine.Random.Range(0, 110);
        }

        string type;
        if (0 <= percent && percent < 20)
            type = "1_Human+1_Ringer";
        else if (20 <= percent && percent < 60)
            type = "1_NPC";
        else if (60 <= percent && percent < 100)
            type = "2_Item";
        else
            type = "1_CureAll+1_Water";

        return type;
    }
    
    private ItemManager.ItemCategory randomItem(Dictionary<string,int> itemCount)
    {
        return ItemManager.ItemCategory.Water;
        int percent = UnityEngine.Random.Range(0, 100);

        if (0 <= percent && percent < 60)
        {

            if (itemCount["Water"] != 0)
            {
                itemCount["Water"]--;
                return ItemManager.ItemCategory.Water;
            }
            else if (itemCount["Can"] != 0)
            {
                itemCount["Can"]--;
                return ItemManager.ItemCategory.Can;
            }
            else if (itemCount["Medicine"] != 0)
            {
                itemCount["Medicine"]--;
                return ItemManager.ItemCategory.Medicine;
            }
            else if (itemCount["Bandage"] != 0)
            {
                itemCount["Bandage"]--;
                return ItemManager.ItemCategory.Bandage;
            }
            else
                return randomItem(itemCount);
            
        }
        else if(60 <= percent && percent < 80)
        {
            if (itemCount["Capsule"] != 0)
            {
                itemCount["Capsule"]--;
                Array values = Enum.GetValues(typeof(ItemManager.ItemCategory));
                ItemManager.ItemCategory randombar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                while (ItemManager.CategoryToType(randombar) != ItemManager.ItemType.Capsule)
                {
                    randombar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                }
                return randombar;
            }
            else
                return randomItem(itemCount);
        }
        else if(80 <= percent && percent < 90)
        {
            if (itemCount["Injector"] != 0)
            {
                itemCount["Injector"]--;
                Array values = Enum.GetValues(typeof(ItemManager.ItemCategory));
                ItemManager.ItemCategory randombar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                while (ItemManager.CategoryToType(randombar) != ItemManager.ItemType.Injector)
                {
                    randombar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                }
                return randombar;
            }
            else
                return randomItem(itemCount);
        }
        else
        {
            if (itemCount["Equip"] != 0)
            {
                itemCount["Equip"]--;
                Array values = Enum.GetValues(typeof(ItemManager.ItemCategory));
                ItemManager.ItemCategory randombar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                while (ItemManager.CategoryToType(randombar) != ItemManager.ItemType.Armor ||
                    ItemManager.CategoryToType(randombar) != ItemManager.ItemType.Weapon)
                {
                    randombar = (ItemManager.ItemCategory)values.GetValue(UnityEngine.Random.Range(0, values.Length));
                }
                return randombar;
            }
            else
                return ItemManager.ItemCategory.Empty;
        }
    }

    private BoardManager.EnemyType randomEnemy()
    {
        int randomEnemy = UnityEngine.Random.Range(0, 3);
        switch (randomEnemy)
        {
            case 0:
                return BoardManager.EnemyType.Dog;
            case 1:
                return BoardManager.EnemyType.Rat;
            default:
                return BoardManager.EnemyType.Human;
        }
    }

    private BoardManager.NPCType randomNPC()
    {
        
        Array values = Enum.GetValues(typeof(BoardManager.NPCType));
        return (BoardManager.NPCType)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }

    private List<E> ShuffleList<E>(List<E> inputList)
    {
        List<E> randomList = new List<E>();

        System.Random r = new System.Random();
        int randomIndex = 0;
        while (inputList.Count > 0)
        {
            randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
            randomList.Add(inputList[randomIndex]); //add it to the new, random list
            inputList.RemoveAt(randomIndex); //remove to avoid duplicates
        }

        return randomList; //return the new random list
    }

}
