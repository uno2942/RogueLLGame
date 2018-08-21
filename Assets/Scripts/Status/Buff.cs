using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * \brief 유닛에 작용하는 버프의 베이스 클래스
 */
public abstract class Buff {
    protected int count;

    /**
     * 버프가 지속되는 카운트를 저장합니다.
     */
    protected Buff( int _count) {
        count = _count;
    }

    public void AddCount(int _count) {
        count += _count;
    }
    public int Count
    {
        get
        {
            return count;
        }
    }
    /**
     *@todo [2018.07.19 변경] Unit.Action action을 받아서 action이 이동 중, 공격 중, 맞는 중에 따라 효과를 다르게 할 예정
     * 이 함수는 유닛에 턴이 지날 때 마다 받는 효과를 지정합니다.
     */
    public abstract void BuffWorkTo( Unit unit, Unit.Action action );
    /**
    * 이 함수는 공격력에 추가되는 값을 반환합니다.(ex. 5를 반환할 경우 유닛의 공격력을 5 더합니다.)
    */
    public abstract int passiveBuffAtk();

    /**
     * 이 함수는 방어력에 추가되는 값을 반환합니다.(ex. 5를 반환할 경우 유닛의 방어력을 5 더합니다.)
     */
    public abstract int passiveBuffDef();

    /**
     * @todo [2018.07.19 변경] Unit.Action action을 받아서 action이 이동 중, 공격 중, 맞는 중에 따라 효과를 다르게 할 예정
     * 이 함수는 데미지에 곱해지는 배율을 반환합니다.(ex. 1.5를 반환할 경우 유닛이 받는 데미지에 1.5배를 곱합니다.)
     */
    public abstract float BuffAction(Unit.Action action);
}
