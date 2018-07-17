using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * \brief 플레이어 게임 오브젝트에 들어가는 클래스
 */
public class Player : Unit {

    private float mp;
    private int hungry;
    private const int maxmp=100;
    private Inventory inventoryList;
    private PlayerAction action; /**< 플레이어가 할 수 있는 action을 담고 있는 PlayerAction 인스턴스를 저장한다. */
    /**
     * Player's mp and hungry degree.
     * Note that HP variable is in Unit class.
     */
    //{@
    public float Mp { get { return mp; } }
    public int MaxMp { get { return maxmp; } }
    public int Hungry { get { return hungry; } }
    //@}
    public PlayerAction Action
    {
        get
        {
            return action;
        }
    }

    public Inventory InventoryList
    {
        get
        {
            return inventoryList;
        }
    }

    public Weapon weapon; /**< 플레이어가 가지고 있는 무기 */
    public Armor armor; /**< 플레이어가 가지고 있는 갑옷 */
    /**
    * Player class have inventory gameobject to put items into inventory.
    */


    /**
     * 플레이어의 상태를 초기화하고, MpBar와 HpBar를 초기화한다. 그 후 action, weapon, armor를 초기화한다.
     */
    void Start() {
        attack = 1;
        defense = 1;
        maxhp = 100;
        hp = maxhp;
        mp = maxmp;
        hungry = 0;
        inventoryList = new Inventory();
        inventoryList.Initialize();
        GameObject.Find( "PlayerHPBar" ).GetComponent<Slider>().value = hp;
        GameObject.Find( "PlayerMPBar" ).GetComponent<Slider>().value = mp;
        action = new PlayerAction();
        weapon = new DefaultWeapon();
        armor = new DefaultArmor();
    }
    /**
     * It overrides ChangeHp function in Unit class to modify HPBar and MPBar Slider.
     */

    public override void ChangeHp( float delta ) {
        hp += delta;
        if( hp >= 100 )
            hp = 100;
        GameObject.Find( "PlayerHPBar" ).GetComponent<Slider>().value = hp;
    }
    public void ChangeMp( float delta ) {
        mp += delta;
        if( mp < 0 ) {
            hp += mp;
            mp = 0;
        }
        if( mp >= 100 )
            mp = 100;
        GameObject.Find( "PlayerMPBar" ).GetComponent<Slider>().value = mp;
    }

    public void ChangeHungry( int delta ) {
        hungry += delta;
        if( hungry < 0 )
            hungry = 0;
    }
    
    public void SetMpZero() {
        if( mp < 0 ) {
            hp += mp;
        }
        mp = 0;
    }
    public void SetMpBy30() {
        mp = 30;
    }
    /**
    * 플레이어가 하는 액션을 PlayerAction 인스턴스로 보내주는 함수. 이전에 짠 코드들과 호환성을 위한 코드이다.
    * @see PlayerAction
    */
    //{@
    public void DumpItem( int index ) {
        action.DumpItem( index );
    }

    public void UseItem( int index ) {
        action.UseItem( index );
    }
    public void InjectItem(int index ) {
        action.InjectItem( index );
    }

    public void ThrowItem( int index ) {
        action.ThrowAwayItem( index );
    }
    public void EquipItem( int index ) {
        action.EquipItem( index );
    }

    public void UnequipItem( int index, bool GoNextTurn = true ) {
        action.UnequipItem( index, GoNextTurn );
    }
    /**
     * @todo I need to implement this part
     */
    public void EatCapsule( int index ) {
        action.EatCapsule( index );
    }
    //@}

    /** 플레이어의 공격력+플레이어가 가진 무기+플레이어의 상태 이상을 기반으로 플레이어의 공격력을 반환 */
    public override int FinalAttackPower() {
        int attacktemp = attack+weapon.AttackPower;
        Debug.Log( attacktemp );
        foreach( Buff buff in Bufflist ) {
            attacktemp += buff.passiveBuffAtk();
        }
        return attacktemp;
    }
    /** 플레이어의 방어력+플레이어가 가진 갑옷+플레이어의 상태 이상을 기반으로 플레이어의 방어력을 반환 */
    public override int FinalDefensePower() {
        int defensetemp = defense+armor.DefensivePower;
        foreach( Buff buff in Bufflist ) {
            defensetemp += buff.passiveBuffDef();
        }
        return defensetemp;
    }
}