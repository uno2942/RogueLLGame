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
    public virtual void AddBuff(Buff _buff)
    {
        Buff buff = bufflist.Find( x => x.GetType().Equals( _buff.GetType() ) );
        if( Equals( buff, null ) ) {
            if( _buff is Adrenaline )
                bufflist.Add( new Adrenaline( _buff.Count ) );
            else if( _buff is Bleed )
                bufflist.Add( new Bleed( _buff.Count ) );
            else if( _buff is Burn )
                bufflist.Add( new Burn( _buff.Count ) );
            else if( _buff is Caffeine )
                bufflist.Add( new Caffeine( _buff.Count ) );
            else if( _buff is Defenseless )
                bufflist.Add( new Defenseless( _buff.Count ) );
            else if( _buff is Full )
                bufflist.Add( new Full( _buff.Count ) );
            else if( _buff is Giddiness )
                bufflist.Add( new Giddiness( _buff.Count ) );
            else if( _buff is Hallucinated )
                bufflist.Add( new Hallucinated( _buff.Count ) );
            else if( _buff is Hunger )
                bufflist.Add( new Hunger() );
            else if( _buff is Morfin )
                bufflist.Add( new Morfin( _buff.Count ) );
            else if( _buff is Poison )
                bufflist.Add( new Poison( _buff.Count ) );
            else if( _buff is Relieved )
                bufflist.Add( new Relieved( _buff.Count ) );
            else if( _buff is Renewal )
                bufflist.Add( new Renewal( _buff.Count ) );
            else if( _buff is Starve )
                bufflist.Add( new Starve( ) );
            else if( _buff is Stunned )
                bufflist.Add( new Stunned( _buff.Count ) );
        } else
            buff.AddCount( _buff.Count );

        Debug.Log( "Buff: " + _buff.GetType().ToString() + "turn" + _buff.Count );
    }
    /**
     * 유닛의 BuffList에 버프를 빼는 함수(버프 1개만 뺀다. 버프 카운트가 다를 때에 대한 코드는 구현되어 있지 않다.)
     * @todo I need to check whether this code is legable.
     */
    public virtual void DeleteBuff(Buff buff)
    {
        Buff _buff= FindBuff(buff);
        if( _buff != null)
            bufflist.Remove( _buff );
    }

    public bool IsBuffExist(Buff buff){
        return FindBuff(buff) != null;
    }

    public Buff FindBuff(Buff buff ) {
        if( buff != null )
            return bufflist?.Find( x => x.GetType() == buff.GetType() );
        else
            return null;
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

    /**
 * a와 b 사이에 가우시안 분포(근사)에 해당하는 값을 반환해주는 함수입니다.
 * 아직은 못 짜서 Uniform dist.로 하겠습니다.
 * @todo Gaussian으로 수정해야함.
 * 최댓값이 나오도록 하기 위해서 random.range에 a와 b+1을 인자로 줌.
 */
    public static float GaussianDistribution( int a, int b ) { //Unit은 
        Random.InitState( (int) System.DateTime.Now.Ticks );
        return Random.Range( (float)a, (float)b+1 );
    }
}



