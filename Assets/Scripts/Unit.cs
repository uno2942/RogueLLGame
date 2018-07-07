using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {


    protected int attack;
    protected int defense;
    protected int maxhp;
    protected float hp;
    protected GameManager gameManager;
    protected List<Buff> bufflist;
    /**
     * \brief 공격력
     */
    public int Attack
    {
        get
        {
            return attack;
        }
    }
    /**
    * \brief 방어력
    */
    public int Defense
    {
        get
        {
            return defense;
        }

    }
    /**
    * \brief 현재 체력
    */
    public float Hp
    {
        get
        {
            return hp;
        }
    }
    /**
    * \brief 최대 체력
    */
    public int MaxHp
    {
        get
        {
            return maxhp;
        }
    }
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

    
    public void ChangeAttack(int delta)
    {
        attack += delta;
    }
    public void ChangeDefense( int delta ) {
        defense += delta;
    }
    public virtual void ChangeHp( float delta )
    {
        hp += delta;
    }
    public virtual void ChangeMaxHp( int delta ) {
        hp += delta;
    }

    /**
     * buff instance 안에 이미 buff가 지속되는 count가 들어가 있다.)
     */
    public void AddBuff(Buff buff)
    {
        if( Equals( bufflist.Find( x => x.GetType().Equals( typeof( Hallucinated ) ) ), null ) )
            bufflist.Add(buff);
    }
    /**
     * @todo I need to check whether this code is legable.
     */
    public void DeleteBuff(Buff buff)
    {
        bufflist.Remove( bufflist.Find( x => x.GetType().Equals( buff.GetType() ) ) );
    }

    /**
     * @todo we need to implement this funciton.
     */
    public void DebugStatus()
    {

    }

    public virtual int FinalAttackPower() {
        int attacktemp = attack;
        foreach( Buff buff in Bufflist ) {
            attacktemp += buff.passiveBuffAtk();
        }
        return attacktemp;
    }

    public virtual int FinalDefensePower() {
        int defensetemp = defense;
        foreach( Buff buff in Bufflist ) {
            defensetemp += buff.passiveBuffDef();
        }
        return defensetemp;
    }

    public float FinalMagnification() {
        float magnification = 1;

        foreach( Buff buff in Bufflist ) {
            magnification *= buff.passiveBuffFinal();
        }
        return magnification;
    }
}



