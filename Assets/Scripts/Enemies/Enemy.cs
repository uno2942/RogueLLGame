using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Buff Debuff()
    {
        return debuff;
    }

    public float DebuffPercent()
    {
        return debuffPercent;
    }


    public int Level { get { return level; } }

    


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
