using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equip {

    protected int attackPower;
    public int AttackPower
    {
        get
        {
            return attackPower;
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
