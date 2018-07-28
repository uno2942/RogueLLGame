using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
/**
 * \brief 맵 파일을 파싱하는 클래스
 */
public class MapParser {

    /**
     * @todo 첫 번째 열은 버려야 함.(데이터에 대한 설명을 담고 있음.)
     */
    public void parse( ref List<List<MapTile>> mapTiles ) {
        var mapData = File.ReadAllLines( Application.dataPath + "/Resources" + "Map1.txt" );
        foreach( string str in mapData ) {
            var temp = str.Split( '\t' );
            mapTiles[0].Add( new MapTile( int.Parse(temp[ 0 ]), int.Parse( temp[ 1 ]), ConvertLetterToMapType( temp[ 2 ] ) ));
        }
    }
    private BoardManager.RoomType ConvertLetterToMapType(string str ) {
        switch(str) {
        case "N": return BoardManager.RoomType.NormalRoom;
        case "H": return BoardManager.RoomType.Hall;
        case "B": return BoardManager.RoomType.BossRoom;
        case "D": return BoardManager.RoomType.DrugRoom;
        case "L": return BoardManager.RoomType.LockedRoom;
        case "E": return BoardManager.RoomType.End;
        }
        return BoardManager.RoomType.Empty;
    }
}