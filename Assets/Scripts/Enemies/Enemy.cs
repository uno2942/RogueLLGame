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

    protected void OnMouseUpAsButton() {
        player.PlayerAction.Attack( this );
        Debug.Log( "플레이어 공격" );
    }


    /** \change enemy's Status by isHallucinated
     */
    public virtual void changeStatus(bool isHallucinated)
    {

    }


    /** \Works when enemy dies, and drop item :case by case.
    */
    public virtual void dropItem()
    {

    }

}
