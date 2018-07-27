using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Enemy
{
    
    /** 
     * There is a debug code.
     * incomplete:: shld be read settings file
     */
    private void Start()
    {
        Debug.Log("사람 나타남");
        level = 1;
        attack = 3; //shld be decided by level and setting file
        defense = 2;
        maxhp = 24;
        hp = maxhp;
        debuffPercent = 0.0f;
        action = new EnemyAction(this);
        debuff = null;
        player = GameObject.Find( "Player" ).GetComponent<Player>();
    }


    /** \change enemy's Status by level and isHallucinated
     */
    public override void changeStatus(bool isHallucinated)
    {
        //read setting file and change
        if (isHallucinated == true)
        {
            attack = 4;
            defense = 4;
            
        }
        else
        {
            attack = 3;
            defense = 2;
            
        }
    }

    /** \ incomplete: shld access at room
     * 
     */


    public override void dropItem()
    {
        float dropPercent;
        if (player.InventoryList.CheckItem(ItemManager.Label.AdrenalineDrug) == false
            && player.InventoryList.CheckItem(ItemManager.Label.MorfinDrug) == false)
        {
            if (player.Bufflist.Exists(x => x.GetType().Equals(typeof(Hallucinated))))
            {
                dropPercent = 1.01f;
            }
            else dropPercent = 0.25f;

        }
        else dropPercent = 0.1f;

        if(Random.value < dropPercent)
        {
            // item drop
        }
    }
}