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

    public bool isStunned=false;
    public bool prevIsStunned = false;
    public bool isHallucinated = false;
    public bool isHungry = false;
    public bool isStarved = false;
    public bool isFull = false;
    Image hpBar;
    Image mpBar;
    public Stunned stunned;
    private Inventory inventoryList;
    private PlayerAction playerAction; /**< 플레이어가 할 수 있는 action을 담고 있는 PlayerAction 인스턴스를 저장한다. */
    /**
     * Player's mp and hungry degree.
     * Note that HP variable is in Unit class.
     */
    //{@
    public float Mp { get { return mp; } }
    public int MaxMp { get { return maxmp; } }
    public int Hungry { get { return hungry; } }
    //@}
    public PlayerAction PlayerAction
    {
        get
        {
            return playerAction;
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
        hungry = 50;
        inventoryList = new Inventory();
        inventoryList.Initialize();
        (hpBar=GameObject.Find( "healthbar" ).GetComponent<Image>()).fillAmount = ((float)hp)/maxhp;
        (mpBar=GameObject.Find( "mpbar" ).GetComponent<Image>()).fillAmount = ( (float) mp ) / maxmp;
        playerAction = new PlayerAction();
        weapon = new DefaultWeapon();
        armor = new DefaultArmor();
    }
    /**
     * It overrides ChangeHp function in Unit class to modify HPBar and MPBar Slider.
     */
     
    public Inventory GetInventoryList() {
        return InventoryList;
    }

    public override void ChangeHp( float delta ) {
        hp += (int)delta;
        if( hp >= 100 )
            hp = 100;
        hpBar.fillAmount = ( (float) hp ) / maxhp;
    }
    public void ChangeMp( float delta ) {
        mp += delta;
        if( mp < 0 ) {
            hp += (int)mp;
            mp = 0;
        }
        if( mp >= 100 )
            mp = 100;
        mpBar.fillAmount = ( (float) mp ) / maxmp;
    }

    public void ChangeHungry( int delta ) {
        hungry += delta;
        if( hungry < 0 )
            hungry = 0;
    }
    
    public void SetMpZero() {
        if( mp < 0 ) {
            hp += (int)mp;
        }
        mp = 0;
    }
    public void SetMpBy30() {
        mp = 30;
    }

    public void SetMpBy100() {
        mp = 100;
    }
    /**
    * 플레이어가 하는 액션을 PlayerAction 인스턴스로 보내주는 함수. 이전에 짠 코드들과 호환성을 위한 코드이다.
    * @see PlayerAction
    */
    //{@
    public void DumpItem( int index ) {
        playerAction.DumpItem( index );
    }

    public void UseItem( int index ) {
        playerAction.UseItem( index );
    }
    public void SpreadWater( int index ) {
        playerAction.SpreadWater( index );
    }
     public void UseItem( ItemManager.Label label ) {
        playerAction.UseItem( inventoryList.Getindex(label) );
    }

    public void ThrowItem( int index ) {
        playerAction.ThrowAwayItem( index );
    }
    public void EquipItem( int index ) {
        playerAction.EquipItem( index );
    }

    public void UnequipItem( int index, bool GoNextTurn = true ) {
        playerAction.UnequipItem( index, GoNextTurn );
    }
    /**
     * @todo I need to implement this part
     */
    //@}

    /** 플레이어의 공격력+플레이어가 가진 무기+플레이어의 상태 이상을 기반으로 플레이어의 공격력을 반환 */
    public override int FinalAttackPower() {
        int attacktemp = attack;
        switch( weapon.rank ) {
        case "common": attacktemp += (int) GaussianDistribution( weapon.AttackPower, weapon.AttackPower * 2 + 3 ); break;
        case "rare": attacktemp += (int) GaussianDistribution( weapon.AttackPower, weapon.AttackPower * 3 + 2 ); break;
        case "legendary": attacktemp += (int) GaussianDistribution( weapon.AttackPower, weapon.AttackPower * 4 + 1 ); break;
        default: break;
        }
        Debug.Log( attacktemp );
        foreach( Buff buff in Bufflist ) {
            attacktemp += buff.passiveBuffAtk();
        }
        return attacktemp;
    }
    /** 플레이어의 방어력+플레이어가 가진 갑옷+플레이어의 상태 이상을 기반으로 플레이어의 방어력을 반환
     * @todo 기획서가 뭔가 이상하니 물어봅시다.
     */
    public override int FinalDefensePower() {
        int defensetemp = defense;
        switch( armor.rank ) {
        case "common": defensetemp += (int) GaussianDistribution( armor.DefensivePower, armor.DefensivePower * 2 + 3 ); break;
        case "rare": defensetemp += (int) GaussianDistribution( armor.DefensivePower, armor.DefensivePower * 3 + 2 ); break;
        case "legendary": defensetemp += (int) GaussianDistribution( armor.DefensivePower, armor.DefensivePower * 4 + 1 ); break;
        default: break;
        }
        foreach( Buff buff in Bufflist ) {
            defensetemp += buff.passiveBuffDef();
        }
        return defensetemp;
    }

    /**
 * a와 b 사이에 가우시안 분포(근사)에 해당하는 값을 반환해주는 함수입니다.
 * 아직은 못 짜서 Uniform dist.로 하겠습니다.
 * @todo Gaussian으로 수정해야함.
 */
    public static float GaussianDistribution( int a, int b ) {
        Random.InitState( (int) System.DateTime.Now.Ticks );
        return Random.Range( a, b );
    }
}