using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** \class Enemy 
 * \brief This class is the base class for various enemy classes.
 */


public class Enemy : Unit
{

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
        boardManager = GameObject.Find( "BoardManager" ).GetComponent<BoardManager>();
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


    /** \Works when enemy dies, and drop item :case by case.
    */

}
