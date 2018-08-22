using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * \brief 플레이어와 적의 베이스 클래스
 */
public class Unit : MonoBehaviour {

    public enum Action { Default, Move, Rest, Attack, Hitted}; /** 유닛이 이동 중인지(플레이어 한정), 공격 하고 있는지, 공격 당하고 있는지의 정보를 담음 */
    
    protected int attack;
    protected int defense;
    protected int maxhp;
    protected int hp;
    protected GameManager gameManager;
    protected List<Buff> bufflist;

    public int Attack
    {
        get
        {
            return attack;
        }
    }    /**<  \brief 공격력 */

    public int Defense
    {
        get
        {
            return defense;
        }

    }    /**<    * \brief 방어력    */

    public int Hp
    {
        get
        {
            return hp;
        }
    }    /**<    * \brief 현재 체력    */
    
    public int MaxHp
    {
        get
        {
            return maxhp;
        }
    }/**<    \brief 최대 체력    */
    public List<Buff> Bufflist
    {
        get
        {
            return bufflist;
        }
    }

    /**
     * @todo I need to check whether this code is legable. 
     */
    private void Awake()
    {
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
        bufflist = new List<Buff>();
    }

    /** 유닛의 공격력을 영구적으로 증가시키는 함수 */
    public void ChangeAttack(int delta)
    {
        attack += delta;
    }
    /** 유닛의 방어력을 영구적으로 증가시키는 함수 */
    public void ChangeDefense( int delta ) {
        defense += delta;
    }
    /** 유닛의 체력을 영구적으로 증가시키는 함수 */
    public virtual void ChangeHp( float delta )
    {
        hp += (int)delta;
    }
    /** 유닛의 최대 체력을 영구적으로 증가시키는 함수 */
    public virtual void ChangeMaxHp( int delta ) {
        maxhp += delta;
        hp += delta;
    }

    /**
     * 유닛의 Bufflist에 버프를 넣는 함수
     */
    public void AddBuff(Buff _buff)
    {
        Buff buff = bufflist.Find( x => x.GetType().Equals( _buff.GetType() ) );
        if( Equals( buff, null ) )
            bufflist.Add( buff );
        else
            buff.AddCount( _buff.Count);
    }
    /**
     * 유닛의 BuffList에 버프를 빼는 함수(버프 1개만 뺀다. 버프 카운트가 다를 때에 대한 코드는 구현되어 있지 않다.)
     * @todo I need to check whether this code is legable.
     */
    public void DeleteBuff(Buff buff)
    {
        bufflist.Remove( bufflist.Find( x => x.GetType().Equals( buff.GetType() ) ) );
    }
    public bool IsBuffExist(Buff buff){
        return (bufflist?.Find(x => x.GetType().Equals( buff.GetType()))!=null);
    }

    public virtual int FinalAttackPower() {
        int attacktemp = attack;
        foreach( Buff buff in Bufflist ) {
            attacktemp += buff.passiveBuffAtk();
        }
        return attacktemp;
    }

    /** 유닛의 공격력+유닛의 상태 이상을 기반으로 유닛의 공격력을 반환 */
    public virtual int FinalDefensePower() {
        int defensetemp = defense;
        foreach( Buff buff in Bufflist ) {
            defensetemp += buff.passiveBuffDef();
        }
        return defensetemp;
    }

    /** 유닛의 방어력+유닛의 상태 이상을 기반으로 유닛의 방어력을 반환 */
    public float FinalMagnification(Action action) {
        float magnification = 1;

        foreach( Buff buff in Bufflist ) {
            magnification *= buff.BuffAction(action);
        }
        return magnification;
    }
}



