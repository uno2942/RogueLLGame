using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {
    protected int defaultA;
    protected int defaultD;
    protected int delA;
    protected int delD;

    public override void ChangeStatus(bool isHallucinated)
    {
        if (isHallucinated)
        {
            attack = defaultA + delA;
            defense = defaultD + delD;

        }
        else
        {
            attack = defaultA;
            defense = defaultD;
        }
    }

    private void OnDestroy()
    {
        Debug.Log ("검정키 줍니다");
        ItemManager itemManager = GameObject.Find ("ItemManager").GetComponent<ItemManager> ();
        
        Vector3 tnowPos = transform.position;
        Vector2 nowPos;
        nowPos.x = tnowPos.x;
        nowPos.y = tnowPos.y;

        itemManager.InstantiateItem (ItemManager.ItemCategory.BlackCard, nowPos);
    }
}
