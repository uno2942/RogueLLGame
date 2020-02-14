using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : Item{

    public ItemManager.Rank rank;

    public virtual void onMpTurn() //MP감소/회복턴시 실행
    {

    }

    public virtual void onHungerTurn() //허기증가시 실행
    {

    }

    public virtual void onHalluciCheck() //환각체크시
    {

    }

    public virtual void onEquip() //장착시 실행
    {

    }

    public void setRank( ItemManager.ItemCategory category ) {
        BoardManager boardManager = GameObject.Find( "BoardManager" ).GetComponent<BoardManager>();
        ItemManager itemManager = GameObject.Find( "ItemManager" ).GetComponent<ItemManager>();

        int floor = boardManager.WhichFloor;
        int cPer = 77 - 7 * floor;
        int rPer = 20 + 5 * floor;
        int lPer = 3 + 2 * floor;
        UnityEngine.Random.InitState( (int) System.DateTime.Now.Ticks );

        int rand = UnityEngine.Random.Range( 0, 100 );
        bool rankSet = false;

        while( !rankSet ) {
            rand = UnityEngine.Random.Range( 0, 100 );
            if( rand < cPer ) {
                if( itemManager.cEquip.Contains(category) ) {
                    rankSet = true;
                    rank = ItemManager.Rank.Common;
                }
            } else if( rand < cPer + rPer ) {
                if( itemManager.rEquip.Contains( category ) ) {
                    rankSet = true;
                    rank = ItemManager.Rank.Rare;
                }
            } else {
                if( itemManager.lEquip.Contains( category ) ) {
                    rankSet = true;
                    rank = ItemManager.Rank.Legendary;
                }
            }
        }
        Debug.Log( name + "의 등급은" + rank.ToString() );
    }


    
}
