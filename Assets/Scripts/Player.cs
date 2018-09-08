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
    private int hungryPrevious;
    private const int maxmp=100;

    MessageMaker messageMaker;
    public bool isStunned=false;
    public bool prevIsStunned = false;
    public bool isHallucinated = false;
    public bool isHungry = false;
    public bool isStarved = false;
    public bool isFull = false;
    Transform buffPanelTransform;
    Image hpBar;
    Image mpBar;
    public GameObject[] BuffIcons;
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
    public int HungryPrevious { get { return hungryPrevious; } }
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
    public int weaponindex;
    public Armor armor; /**< 플레이어가 가지고 있는 갑옷 */
    public int armorindex;
    /**
    * Player class have inventory gameobject to put items into inventory.
    */


    /**
     * 플레이어의 상태를 초기화하고, MpBar와 HpBar를 초기화한다. 그 후 action, weapon, armor를 초기화한다.
     */

    public void PlayerReset()
    {
        weaponindex = -1;
        armorindex = -1;
        attack = 2;
        defense = 1;
        maxhp = 150;
        hp = maxhp;
        mp = maxmp;
        hungry = 50;
        hungryPrevious = 50;
        inventoryList = new Inventory ();
        inventoryList.Initialize ();
        (hpBar = GameObject.Find ("healthbar").GetComponent<Image> ()).fillAmount = ((float) hp) / maxhp;
        (mpBar = GameObject.Find ("mpbar").GetComponent<Image> ()).fillAmount = ((float) mp) / maxmp;
        playerAction = new PlayerAction ();
        weapon = new DefaultWeapon ();
        armor = new DefaultArmor ();
        buffPanelTransform = GameObject.Find ("BuffPanel").transform;
        messageMaker = GameObject.Find ("Logger").GetComponent<MessageMaker> ();

    }
    void Start() {
        weaponindex = -1;
        armorindex = -1;
        attack = 2;
        defense = 1;
        maxhp = 150;
        hp = maxhp;
        mp = maxmp;
        hungry = 50;
        hungryPrevious = 50;
        inventoryList = new Inventory();
        inventoryList.Initialize();
        (hpBar=GameObject.Find( "healthbar" ).GetComponent<Image>()).fillAmount = ((float)hp)/maxhp;
        (mpBar=GameObject.Find( "mpbar" ).GetComponent<Image>()).fillAmount = ( (float) mp ) / maxmp;
        playerAction = new PlayerAction();
        weapon = new DefaultWeapon();
        armor = new DefaultArmor();
        buffPanelTransform = GameObject.Find( "BuffPanel" ).transform;
        messageMaker = GameObject.Find( "Logger" ).GetComponent<MessageMaker>();
    }
    /**
     * It overrides ChangeHp function in Unit class to modify HPBar and MPBar Slider.
     */
     
    public Inventory GetInventoryList() {
        return InventoryList;
    }

    public override void ChangeHp( float delta ) {
        hp += (int)delta;
        if( hp >= maxhp )
            hp = maxhp;
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

    public void SyncHungry()
    {
        hungryPrevious = hungry;
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

    public void DumpItem(ItemManager.Label label)
    {
        playerAction.DumpItem(inventoryList.Getindex(label));
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

    public void UnequipItem( int index) {
        playerAction.UnequipItem( index );
    }
    /**
     * @todo I need to implement this part
     */
    //@}

    /** 플레이어의 공격력+플레이어가 가진 무기+플레이어의 상태 이상을 기반으로 플레이어의 공격력을 반환 */
    public override int FinalAttackPower() {
        int attacktemp = (int) Unit.GaussianDistribution( weapon.AttackPowerMin, weapon.AttackPowerMax );
        foreach( Buff buff in Bufflist ) {
            attacktemp += buff.IntermdeiateBuffAtk();
        }
        return attacktemp;
    }
    /** 플레이어의 방어력+플레이어가 가진 갑옷+플레이어의 상태 이상을 기반으로 플레이어의 방어력을 반환
     * @todo 기획서가 뭔가 이상하니 물어봅시다.
     */
    public override int FinalDefensePower() {
        int defensetemp = (int) Unit.GaussianDistribution( armor.DefensivePowerMin, armor.DefensivePowerMax );

        foreach( Buff buff in Bufflist ) {
            defensetemp += buff.IntermdeiateBuffDef();
        }
        if( armor.IsDestroyed() == true ) {
            int tempindex = armorindex;
            UnequipItem( tempindex );
            DumpItem( tempindex );
        }
            return defensetemp;
    }

    

    public override void AddBuff( Buff _buff ) {
        Buff buff = bufflist.Find( x => x.GetType().Equals( _buff.GetType() ) );
        if( Equals( buff, null ) ) {
            if( _buff is Adrenaline )
                GameObject.Instantiate( BuffIcons[ 0 ], buffPanelTransform );
            else if( _buff is Bleed )
                GameObject.Instantiate( BuffIcons[ 1 ], buffPanelTransform );
            else if( _buff is Burn )
                GameObject.Instantiate( BuffIcons[ 2 ], buffPanelTransform );
            else if( _buff is Caffeine )
                GameObject.Instantiate( BuffIcons[ 3 ], buffPanelTransform );
            else if( _buff is Defenseless )
                GameObject.Instantiate( BuffIcons[ 4 ], buffPanelTransform );
            else if( _buff is Full )
                GameObject.Instantiate( BuffIcons[ 5 ], buffPanelTransform );
            else if( _buff is Giddiness )
                GameObject.Instantiate( BuffIcons[ 6 ], buffPanelTransform );
            else if( _buff is Hunger )
                GameObject.Instantiate( BuffIcons[ 7 ], buffPanelTransform );
            else if( _buff is Morfin )
                GameObject.Instantiate( BuffIcons[ 8 ], buffPanelTransform );
            else if( _buff is Poison )
                GameObject.Instantiate( BuffIcons[ 9 ], buffPanelTransform );
            else if( _buff is Relieved )
                GameObject.Instantiate( BuffIcons[ 10 ], buffPanelTransform );
            else if( _buff is Renewal )
                GameObject.Instantiate( BuffIcons[ 11 ], buffPanelTransform );
            else if( _buff is Starve )
                GameObject.Instantiate( BuffIcons[ 12 ], buffPanelTransform );
            else if( _buff is Stunned )
                GameObject.Instantiate( BuffIcons[ 13 ], buffPanelTransform );
        }
        base.AddBuff( _buff );
        messageMaker.MakeBuffMessage( _buff );
    }

    public override void DeleteBuff(Buff _buff)
    {
        Buff buff = bufflist.Find(x => x.GetType().Equals(_buff.GetType()));
        if (!Equals(buff, null))
        {
            GameObject buffPanel = GameObject.Find("BuffPanel");

            if (_buff is Adrenaline)
                 Destroy(buffPanel.transform.Find("Adrenaline(Clone)").gameObject);                         
            else if (_buff is Bleed)
                Destroy(buffPanel.transform.Find("Bleed(Clone)").gameObject);
            else if (_buff is Burn)
                Destroy(buffPanel.transform.Find("Burn(Clone)").gameObject);
            else if (_buff is Caffeine)
                Destroy(buffPanel.transform.Find("Caffeine(Clone)").gameObject);
            else if (_buff is Defenseless)
                Destroy(buffPanel.transform.Find("Defenseless(Clone)").gameObject);
            else if (_buff is Full)
                Destroy(buffPanel.transform.Find("Full(Clone)").gameObject);
            else if (_buff is Giddiness)
                Destroy(buffPanel.transform.Find("Giddiness(Clone)").gameObject);
            else if (_buff is Hunger)
                Destroy(buffPanel.transform.Find("Hunger(Clone)").gameObject);
            else if (_buff is Morfin)
                Destroy(buffPanel.transform.Find("Morfin(Clone)").gameObject);
            else if (_buff is Poison)
                Destroy(buffPanel.transform.Find("Poison(Clone)").gameObject);
            else if (_buff is Relieved)
                Destroy(buffPanel.transform.Find("Relieved(Clone)").gameObject);
            else if (_buff is Renewal)
                Destroy(buffPanel.transform.Find("Renewal(Clone)").gameObject);
            else if (_buff is Starve)
                Destroy(buffPanel.transform.Find("Starve(Clone)").gameObject);
            else if (_buff is Stunned)
                Destroy(buffPanel.transform.Find("Stunned(Clone)").gameObject);
        }
        base.DeleteBuff(_buff);
     }


}