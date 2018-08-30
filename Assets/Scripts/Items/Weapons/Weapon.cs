using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equip {

    protected int attackPowerMin;
    protected int attackPowerMax;
    public int AttackPowerMin
    {
        get
        {
            return attackPowerMin;
        }
    }
    public int AttackPowerMax
    {
        get
        {
            return attackPowerMax;
        }
    }

    public virtual void SetMaxAtkbyRank( ItemManager.Rank rank ) {
        switch( rank ) {
        case ItemManager.Rank.Common: attackPowerMax = attackPowerMin * 2 - 1; break;
        case ItemManager.Rank.Rare: attackPowerMax = attackPowerMin * 3 - 2; break;
        case ItemManager.Rank.Legendary: attackPowerMax = attackPowerMin * 4 - 3; break;
        default: attackPowerMax = attackPowerMin; Debug.Log( "무기 공격력 최댓값 설정 오류" ); break;
        }
    }



    public virtual void Equip(Player player ) { //첫 착용시 플레이어에게 적용되는 효과

    }
    public virtual void Check(Player player) //플레이어에게 지속적으로 작용하는 효과
        {

    }
    public virtual void Attack(Enemy enemy )  //적을 공격할 때 발동하는 효과
        {

    }

    public virtual void UnEquip(Player player ) { //해제시 플레이어에게 적용되는 효과

    }

    public virtual bool IsDestroyed() {
        return false;
    }
    //set은 private
}
