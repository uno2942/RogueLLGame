using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
/**
 * \brief 맵 파일을 파싱하는 클래스
 */
public class MapGenerator {

    /**
     * @todo 첫 번째 열은 버려야 함.(데이터에 대한 설명을 담고 있음.)
     */

    public List<List<MapTile>> Maps;

    public void parse(ref List<List<MapTile>> mapTiles) {

        int i;
        for (i = 0; i < 10; i++)
        {
            var mapData = File.ReadAllLines(Application.dataPath + "/Resources" + "Map" + i + ".txt");
            foreach (string str in mapData)
            {
                var temp = str.Split('\t');
                Maps[i].Add(new MapTile(int.Parse(temp[0]), int.Parse(temp[1]), ConvertLetterToMapType(temp[2])));
            }
        }
        

        for (i = 0; i < 6; i++)
        {
            mapTiles.Add(Maps[Random.Range(0, 10)]);
            foreach(MapTile tile in mapTiles[i])
            {
                tile.AddEnemy(GenEnemy(tile.roomType, i));
                tile.AddItem(GenItem(tile.roomType, i));
                tile.AddNPC(GenNPC(tile.roomType, i));
            }
        }
    }
    private BoardManager.RoomType ConvertLetterToMapType(string str ) {
        switch(str) {
            case "N": return BoardManager.RoomType.NormalRoom;
            case "H": return BoardManager.RoomType.Hall;
            case "B": return BoardManager.RoomType.BossRoom;
            case "D": return BoardManager.RoomType.DrugRoom;
            case "L": return BoardManager.RoomType.LockedRoom;
            case "S": return BoardManager.RoomType.Stair;
            case "R": return BoardManager.RoomType.RestRoom;
            case "Q": return BoardManager.RoomType.Equipment;
            case "P": return BoardManager.RoomType.PlayerStart;
            case "E": return BoardManager.RoomType.End;
        }
        return BoardManager.RoomType.Empty;
    }
    private void GenMapObject(List<List<MapTile>> mapTiles) { }
    private List<Enemy> GenEnemy(BoardManager.RoomType type, int floor) { }
    private List<Item> GenItem(BoardManager.RoomType type, int floor) { }
    private List<NPC> GenNPC(BoardManager.RoomType type, int floor) { }

}