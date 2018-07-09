using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{

    /** 
* \access on player to decrease player's hp
*/
    public Player player;
    


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    /** 
* \\ 모든 몹이 공통으로 사용하는 attack 함수로 데미지를 가한 후 특성화된 virtual debuff 발동
* \\ 인자로 Enemy를 받아야 한다(Player는 getcomponent로 접근)
*/
    public void attack(Enemy enemy)
    {
        float temp = (enemy.FinalAttackPower() - player.FinalDefensePower());

        if (player.Bufflist.Exists(x => x.GetType().Equals(typeof(Poison))))
        {
            temp += 1.0f;
        }
        if (player.Bufflist.Exists(x => x.GetType().Equals(typeof(Paralyzed))))
        {
            temp += 3.0f;
        }

        if (player.Bufflist.Exists(x => x.GetType().Equals(typeof(Adrenaline))))
        {
            temp *= 1.5f;
        }
        if (player.Bufflist.Exists(x => x.GetType().Equals(typeof(Morfin))))
        {
            temp *= 0.5f;
        }
        if (temp <= 1.0f)
            temp = 1;
        player.ChangeHp(-(int)temp);

        float i = Random.value;
        if (i < enemy.DebuffPercent())
        {
            player.AddBuff(enemy.Debuff());
        }

        if (player.Hp <= 0)
            GameObject.Destroy(player);
    }

    /**
     * \ 
     */
    


    /** 
* \special action for boss monsters
*/
    public virtual void other()
    {

    }

}
