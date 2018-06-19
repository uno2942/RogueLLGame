using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** \class Enemy 
 * \brief This class is the base class for various enemy classes.
 */


public class Enemy : Unit
{
    /** 
  * \brief It fixes the inventory size 12.
  */
    private const int invenSize = 12;
    /** 
* \brief The enemy's level.
* \details In the game, there are some cases that may need the change of enemies' level such as hallucination, change of floor.
*/
    protected int level;
    public int Level { get { return level; } }
    protected int number;
    /** \brief Function to change enemy's level by delta.
     */
    public void changeLevel(int delta)
    {
        level += delta;
    }
    
   
}
