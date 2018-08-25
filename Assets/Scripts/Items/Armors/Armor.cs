using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equip{

    protected int defensivePowerMin;
    protected int defensivePowerMax;

    public int DefensivePowerMin
    {
        get
        {
            return defensivePowerMin;
        }
    }

    public virtual void SetMaxDefbyRank( ItemManager.Rank rank ) {
        switch( rank ) {
        case ItemManager.Rank.Common: defensivePowerMax = defensivePowerMin * 2 - 1; break;
        case ItemManager.Rank.Rare: defensivePowerMax = defensivePowerMin * 3 - 2; break;
        case ItemManager.Rank.Legendary: defensivePowerMax = defensivePowerMin * 4 - 3; break;
        default: defensivePowerMax = defensivePowerMin; Debug.Log( "무기 공격력 최댓값 설정 오류" ); break;
        }
    }

    public virtual void Check(Player player ) {

    }

    public virtual bool IsDestroyed() {
        return false;
    }
}
