using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** \class Enemy 
 * \brief This class is the base class for various enemy classes.
 */


public class Enemy : Unit
{
    protected override void Awake() {
        base.Awake();
        boardManager = GameObject.Find( "BoardManager" ).GetComponent<BoardManager>();
    }


    /** 
* \brief The enemy's level.
* \details In the game, there are some cases that may need the change of enemies' level such as hallucination, change of floor.
*/
    protected int level;
    protected Image healthbar;
    /** 
    * Which action does Enemy do?
    */
    protected EnemyAction enemyAction;

    //환각시 층 정보 접근 필요
    protected BoardManager boardManager;
    //환각시 변경 공방량
    private readonly int[] delAD = new int[ 6 ] {1, 1, 3, 4, 7, 9};

    public EnemyAction EnemyAction
    {
        get
        {
            return enemyAction;
        }
    }

    protected Player player;

    protected Buff debuff;
    protected float debuffPercent;

    protected virtual void Start() {
        
        Image[] images = GetComponentsInChildren<Image>();
        foreach( Image image in images ) {
            if( image.name == "health" ) {
                healthbar = image;
                break;
            }
        }
    }
    public override void ChangeHp( float delta ) {
        hp += (int) delta;
        if( hp >= MaxHp )
            hp = MaxHp;
        healthbar.fillAmount = ((float)hp) / MaxHp;
    }

    public Buff Debuff()
    {
        return debuff;
    }

    public float DebuffPercent()
    {
        return debuffPercent;
    }


    public int Level { get { return level; } }

    public void OnClick() {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag( "Enemy" );
        foreach( var enemyObject in enemyList ) {
            if( player.isHallucinated ) {
                enemyObject.GetComponent<Enemy>().ChangeStatus( player.isHallucinated );
            }
        }
        player.PlayerAction.Attack( this );
        Debug.Log( "플레이어 공격" );
    }


    /** \change enemy's Status by isHallucinated
     */
    public virtual void ChangeStatus(bool isHallucinated)
    {
        if( isHallucinated ) {
            ChangeAttack( delAD[ boardManager.WhichFloor ] );
            ChangeDefense( delAD[ boardManager.WhichFloor ] );
        } else {
            ChangeAttack( - delAD[ boardManager.WhichFloor ] );
            ChangeDefense( - delAD[ boardManager.WhichFloor ] );
        }
    }

    public override int FinalAttackPower() {
        int min = attack;
        int max = attack * 2; ;
        if(this is Boss ) {
            max += attack;
        }
        int attackTemp = (int) GaussianDistribution( min, max );
                
        foreach( Buff buff in Bufflist ) {
            attackTemp += buff.passiveBuffAtk();
        }
        return attackTemp;
    }

    /** 유닛의 공격력+유닛의 상태 이상을 기반으로 유닛의 공격력을 반환 */
    public override int FinalDefensePower() {
        int min = defense;
        int max = defense * 2; ;
        if( this is Boss ) {
            max += attack;
        }

        int defenseTemp = (int) GaussianDistribution( min, max );

        foreach( Buff buff in Bufflist ) {
            defenseTemp += buff.passiveBuffDef();
        }
        return defenseTemp;
    }



    /** \Works when enemy dies, and drop item :case by case.
    */

}
