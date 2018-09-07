using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** ItemManager's function is to control item in the game and give proper informations about item to player gameobject.
 */
public class ItemManager : MonoBehaviour {


    public enum Rank {
        Common, Rare, Legendary
    }

    /**
     * \brief Item labels to distinguish
     * \details All the items should have a label, and the items in different floor should have different label \since the player can carry items from previous floor.
     */
    public enum Label {
        Empty, AutoHandgun, BlackKnife, Club, Hammer, InjectorWeapon, Lighter, Mess, Nuckle, SharpDagger, Shock,
        BloodJacket, CleanDoctorCloth, DamagedDoctorCloth, FullPlated, Padding, Patient, Tshirts,
        CaffeinCapsule1, CureAll1, Hallucinogen1, LiquidFlameMedicine1, Painkiller1, PoisonCapsule1, Salt1, Soup1, VitaminTablet1,
        CaffeinCapsule2, CureAll2, Hallucinogen2, LiquidFlameMedicine2, Painkiller2, PoisonCapsule2, Salt2, Soup2, VitaminTablet2,
        CaffeinCapsule3, CureAll3, Hallucinogen3, LiquidFlameMedicine3, Painkiller3, PoisonCapsule3, Salt3, Soup3, VitaminTablet3,
        MorfinDrug, AdrenalineDrug, RingerSolution, Can, Water, Bandage, Medicine, WhiteCard, BlackCard, YellowCard
    };
    /**
     * 아이템 카테고리는 층에 관계없이 아이템을 관리하기 위한 열거형이다.
     */
    public enum ItemCategory {
        Empty, AutoHandgun, BlackKnife, Club, Hammer, InjectorWeapon, Lighter, Mess, Nuckle, SharpDagger, Shock,
        BloodJacket, CleanDoctorCloth, DamagedDoctorCloth, FullPlated, Padding, Patient, Tshirts,
        CaffeinCapsule, CureAll, Hallucinogen, LiquidFlameMedicine, Painkiller, PoisonCapsule, Salt, Soup, VitaminTablet,
        MorfinDrug, AdrenalineDrug, RingerSolution, Can, Water, Bandage, Medicine, WhiteCard, BlackCard, YellowCard
    };
    /**
     * 아이템을 종류에 따라 크게 묶는 열거형이다.
     */
    public enum ItemType {
        Empty, Weapon, Armor, Expenables, Capsule, Injector, Card
    };

    public static ItemType LabelToType( Label lab ) {
        if( lab == Label.Empty ) return ItemType.Empty;
        else if( lab == Label.AutoHandgun || lab == Label.BlackKnife || lab == Label.Club || lab == Label.Hammer || lab == Label.InjectorWeapon || lab == Label.Lighter || lab == Label.Mess || lab == Label.Nuckle || lab == Label.SharpDagger || lab == Label.Shock ) return ItemType.Weapon;
        else if( lab == Label.BloodJacket || lab == Label.CleanDoctorCloth || lab == Label.DamagedDoctorCloth || lab == Label.FullPlated || lab == Label.Padding || lab == Label.Patient || lab == Label.Tshirts ) return ItemType.Armor;
        else if( lab == Label.MorfinDrug || lab == Label.AdrenalineDrug || lab == Label.RingerSolution ) return ItemType.Injector;
        else if( lab == Label.Can || lab == Label.Water || lab == Label.Bandage || lab == Label.Medicine ) return ItemType.Expenables;
        else if( lab == Label.BlackCard || lab == Label.YellowCard || lab == Label.WhiteCard ) return ItemType.Card;
        else return ItemType.Capsule;
    }

    public static ItemType CategoryToType( ItemCategory category ) {
        switch( category ) {
        case ItemCategory.Empty: return ItemType.Empty;
        case ItemCategory.AutoHandgun:
        case ItemCategory.BlackKnife:
        case ItemCategory.Club:
        case ItemCategory.Hammer:
        case ItemCategory.InjectorWeapon:
        case ItemCategory.Lighter:
        case ItemCategory.Mess:
        case ItemCategory.Nuckle:
        case ItemCategory.SharpDagger:
        case ItemCategory.Shock:
            return ItemType.Weapon;
        case ItemCategory.BloodJacket:
        case ItemCategory.CleanDoctorCloth:
        case ItemCategory.DamagedDoctorCloth:
        case ItemCategory.FullPlated:
        case ItemCategory.Padding:
        case ItemCategory.Patient:
        case ItemCategory.Tshirts:
            return ItemType.Armor;
        case ItemCategory.CaffeinCapsule:
        case ItemCategory.CureAll:
        case ItemCategory.Hallucinogen:
        case ItemCategory.LiquidFlameMedicine:
        case ItemCategory.Painkiller:
        case ItemCategory.PoisonCapsule:
        case ItemCategory.Salt:
        case ItemCategory.Soup:
        case ItemCategory.VitaminTablet:
            return ItemType.Capsule;
        case ItemCategory.MorfinDrug:
        case ItemCategory.AdrenalineDrug:
        case ItemCategory.RingerSolution:
            return ItemType.Injector;
        case ItemCategory.Can:
        case ItemCategory.Water:
        case ItemCategory.Bandage:
        case ItemCategory.Medicine:
            return ItemType.Expenables;
        case ItemCategory.WhiteCard:
        case ItemCategory.BlackCard:
        case ItemCategory.YellowCard:
            return ItemType.Card;
        default: return ItemType.Empty;
        }
    }

    public static ItemCategory LabelToCategory( Label label ) {
        if( label == Label.Empty ) return ItemCategory.Empty;
        else if( label == Label.AutoHandgun ) return ItemCategory.AutoHandgun;
        else if( label == Label.BlackKnife ) return ItemCategory.BlackKnife;
        else if( label == Label.Club ) return ItemCategory.Club;
        else if( label == Label.Hammer ) return ItemCategory.Hammer;
        else if( label == Label.InjectorWeapon ) return ItemCategory.InjectorWeapon;
        else if( label == Label.Lighter ) return ItemCategory.Lighter;
        else if( label == Label.Mess ) return ItemCategory.Mess;
        else if( label == Label.Nuckle ) return ItemCategory.Nuckle;
        else if( label == Label.SharpDagger ) return ItemCategory.SharpDagger;
        else if( label == Label.Shock ) return ItemCategory.Shock;
        else if( label == Label.BloodJacket ) return ItemCategory.BloodJacket;
        else if( label == Label.CleanDoctorCloth ) return ItemCategory.CleanDoctorCloth;
        else if( label == Label.DamagedDoctorCloth ) return ItemCategory.DamagedDoctorCloth;
        else if( label == Label.FullPlated ) return ItemCategory.FullPlated;
        else if( label == Label.Padding ) return ItemCategory.Padding;
        else if( label == Label.Patient ) return ItemCategory.Patient;
        else if( label == Label.Tshirts ) return ItemCategory.Tshirts;
        else if( label == Label.MorfinDrug ) return ItemCategory.MorfinDrug;
        else if( label == Label.AdrenalineDrug ) return ItemCategory.AdrenalineDrug;
        else if( label == Label.RingerSolution ) return ItemCategory.RingerSolution;
        else if( label == Label.Can ) return ItemCategory.Can;
        else if( label == Label.Water ) return ItemCategory.Water;
        else if( label == Label.Bandage ) return ItemCategory.Bandage;
        else if( label == Label.Medicine ) return ItemCategory.Medicine;
        else if( label == Label.WhiteCard ) return ItemCategory.WhiteCard;
        else if( label == Label.BlackCard ) return ItemCategory.BlackCard;
        else if( label == Label.YellowCard ) return ItemCategory.YellowCard;
        else if( label == Label.CaffeinCapsule1 || label == Label.CaffeinCapsule2 || label == Label.CaffeinCapsule3 ) return ItemCategory.CaffeinCapsule;
        else if( label == Label.CureAll1 || label == Label.CureAll2 || label == Label.CureAll3 ) return ItemCategory.CureAll;
        else if( label == Label.Hallucinogen1 || label == Label.Hallucinogen2 || label == Label.Hallucinogen3 ) return ItemCategory.Hallucinogen;
        else if( label == Label.LiquidFlameMedicine1 || label == Label.LiquidFlameMedicine2 || label == Label.LiquidFlameMedicine3 ) return ItemCategory.LiquidFlameMedicine;
        else if( label == Label.Painkiller1 || label == Label.Painkiller2 || label == Label.Painkiller3 ) return ItemCategory.Painkiller;
        else if( label == Label.PoisonCapsule1 || label == Label.PoisonCapsule2 || label == Label.PoisonCapsule3 ) return ItemCategory.PoisonCapsule;
        else if( label == Label.Salt1 || label == Label.Salt2 || label == Label.Salt3 ) return ItemCategory.Salt;
        else if( label == Label.Soup1 || label == Label.Soup2 || label == Label.Soup3 ) return ItemCategory.Soup;
        else if( label == Label.VitaminTablet1 || label == Label.VitaminTablet2 || label == Label.VitaminTablet3 ) return ItemCategory.VitaminTablet;
        else return ItemCategory.Empty; //Throw exception을 어떻게 하는지 모르겠어요.


    }

    public static Label CategoryToLabel( ItemCategory category, int floor ) {
        return (Label) Enum.Parse( typeof( Label ), category.ToString() + ( ( 2 + floor ) / 2 ).ToString() );
    }


    public List<ItemCategory> cEquip; //common이 가능한 장비들 목록
    public List<ItemCategory> rEquip; //rare가 가능한 장비들 목록
    public List<ItemCategory> lEquip; //legendary가 가능한 장비들 목록



    private const int floorMax = 3;
    /** To check whether the item is identified, we use dictionary.
     */
    private Dictionary<Label, bool> IsIdentified = new Dictionary<Label, bool>();
    /** It connects item labels with item class
     */
    private Dictionary<Label, Item> labelDic;
    /** The item prefabs.
     * For weapons, armors and foods, the prefab and sprite should coincide.
     * For Capsule, it does not have to because we need to distribute the sprite randomly.
     */
    //{@
    public GameObject[] weaponPrefabs;
    public GameObject[] armorPrefabs;
    public GameObject[] expendablesPrefabs;
    public GameObject[] capsulePrefabs; //Prefab과 Sprite가 일치하도록 넣어야 합니다.
    public GameObject[] injectorPrefabs;
    public GameObject[] cardPrefabs;

    public Sprite[] capsuleSprite;
    //@}

    public BoardManager boardmanager;
    public GameManager gamemanager;

    private Vector2[] monsterGenLocation;

    // Use this for initialization
    /**
     * LabelDic 을 초기화하고, 캡슐을 제외한 아이템의 감정 상태를 true 로 초기화 한다.
     */
    void Start() {

        cEquip = new List<ItemCategory>();
        rEquip = new List<ItemCategory>();
        lEquip = new List<ItemCategory>();

        InitializeEquipRank();





        //아이템 생성좌표: 몬스터 생성것 가져옴
        monsterGenLocation = new Vector2[ 6 ];
        monsterGenLocation[ 0 ] = new Vector2( 0, 2 );
        monsterGenLocation[ 1 ] = new Vector2( -2, 2 );
        monsterGenLocation[ 2 ] = new Vector2( 2, 2 );
        monsterGenLocation[ 3 ] = new Vector2( -3, 2 );
        monsterGenLocation[ 4 ] = new Vector2( 0, 2 );
        monsterGenLocation[ 5 ] = new Vector2( 3, 2 );


        labelDic = new Dictionary<Label, Item>();
        boardmanager = GameObject.Find( "BoardManager" ).GetComponent<BoardManager>() as BoardManager;
        gamemanager = GameObject.Find( "GameManager" ).GetComponent<GameManager>() as GameManager;

        InitLabelDic( labelDic );
        foreach( Label i in System.Enum.GetValues( typeof( Label ) ) ) {
            if( LabelToType( i ) == ItemType.Capsule )
                IsIdentified.Add( i, false );
            else
                IsIdentified.Add( i, true );
        }
        IsIdentified[ Label.Empty ] = false;

        InitializePrefabsRandomly( capsulePrefabs, capsuleSprite );
    }

    public void ItemReset()
    {
        InitializeEquipRank ();
        InitLabelDic (labelDic);
        foreach ( Label i in System.Enum.GetValues (typeof (Label)) )
        {
            if ( LabelToType (i) == ItemType.Capsule )
                IsIdentified.Add (i, false);
            else
                IsIdentified.Add (i, true);
        }
        IsIdentified [Label.Empty] = false;

        InitializePrefabsRandomly (capsulePrefabs, capsuleSprite);

    }

    private void InitializeEquipRank() {
        /*
        cEquip.Add( Label.AutoHandgun );
        cEquip.Add( Label.BlackKnife );
        cEquip.Add( Label.Club );
        cEquip.Add( Label.Hammer );
        cEquip.Add( Label.InjectorWeapon );
        cEquip.Add( Label.Lighter );
        cEquip.Add( Label.Mess );
        cEquip.Add( Label.Nuckle );
        cEquip.Add( Label.SharpDagger );
        cEquip.Add( Label.Shock );

        cEquip.Add( Label.BloodJacket );
        cEquip.Add( Label.CleanDoctorCloth );
        cEquip.Add( Label.DamagedDoctorCloth );
        cEquip.Add( Label.FullPlated );
        cEquip.Add( Label.Padding );
        cEquip.Add( Label.Patient );
        cEquip.Add( Label.Tshirts );*/

        /*Can Be common*/
        //cEquip.Add( Label.AutoHandgun );
        //cEquip.Add( Label.BlackKnife );
        cEquip.Add( ItemCategory.Club );
        cEquip.Add( ItemCategory.Hammer );
        cEquip.Add( ItemCategory.InjectorWeapon );
        cEquip.Add( ItemCategory.Lighter );
        cEquip.Add( ItemCategory.Mess );
        cEquip.Add( ItemCategory.Nuckle );
        cEquip.Add( ItemCategory.SharpDagger );
        //cEquip.Add( Label.Shock );

        cEquip.Add( ItemCategory.BloodJacket );
        //cEquip.Add( Label.CleanDoctorCloth );
        cEquip.Add( ItemCategory.DamagedDoctorCloth );
        //cEquip.Add( Label.FullPlated );
        cEquip.Add( ItemCategory.Padding );
        cEquip.Add( ItemCategory.Patient );
        cEquip.Add( ItemCategory.Tshirts );

        /*Can Be Rare*/
        //rEquip.Add( Label.AutoHandgun );
        rEquip.Add( ItemCategory.BlackKnife );
        rEquip.Add( ItemCategory.Club );
        rEquip.Add( ItemCategory.Hammer );
        rEquip.Add( ItemCategory.InjectorWeapon );
        rEquip.Add( ItemCategory.Lighter );
        rEquip.Add( ItemCategory.Mess );
        rEquip.Add( ItemCategory.Nuckle );
        rEquip.Add( ItemCategory.SharpDagger );
        //rEquip.Add( Label.Shock );

        rEquip.Add( ItemCategory.BloodJacket );
        rEquip.Add( ItemCategory.CleanDoctorCloth );
        rEquip.Add( ItemCategory.DamagedDoctorCloth );
        //rEquip.Add( Label.FullPlated );
        rEquip.Add( ItemCategory.Padding );
        rEquip.Add( ItemCategory.Patient );
        //rEquip.Add( Label.Tshirts );

        /*Can Be Legend*/
        lEquip.Add( ItemCategory.AutoHandgun );
        lEquip.Add( ItemCategory.BlackKnife );
        lEquip.Add( ItemCategory.Club );
        lEquip.Add( ItemCategory.Hammer );
        lEquip.Add( ItemCategory.InjectorWeapon );
        lEquip.Add( ItemCategory.Lighter );
        lEquip.Add( ItemCategory.Mess );
        lEquip.Add( ItemCategory.Nuckle );
        lEquip.Add( ItemCategory.SharpDagger );
        lEquip.Add( ItemCategory.Shock );

        lEquip.Add( ItemCategory.BloodJacket );
        lEquip.Add( ItemCategory.CleanDoctorCloth );
        lEquip.Add( ItemCategory.DamagedDoctorCloth );
        lEquip.Add( ItemCategory.FullPlated );
        lEquip.Add( ItemCategory.Padding );
        lEquip.Add( ItemCategory.Patient );
        //lEquip.Add( ItemCategory.Tshirts );
    }



    // Update is called once per frame
    void Update() {

    }

    /** 라벨에 해당하는 아이템을 반환한다.
     */
    public Item LabelToItem( Label label ) {
        return labelDic[ label ];
    }

    private void InitLabelDic( Dictionary<Label, Item> labelDic ) {

        labelDic[ Label.AutoHandgun ] = new AutoHandgun();
        labelDic[ Label.BlackKnife ] = new BlackKnife();
        labelDic[ Label.Club ] = new Club();
        labelDic[ Label.Hammer ] = new Hammer();
        labelDic[ Label.InjectorWeapon ] = new InjectorWeapon();
        labelDic[ Label.Lighter ] = new Lighter();
        labelDic[ Label.Mess ] = new Mess();
        labelDic[ Label.Nuckle ] = new Nuckle();
        labelDic[ Label.SharpDagger ] = new SharpDagger();
        labelDic[ Label.Shock ] = new Shock();
        labelDic[ Label.BloodJacket ] = new BloodJacket();
        labelDic[ Label.CleanDoctorCloth ] = new CleanDoctorCloth();
        labelDic[ Label.DamagedDoctorCloth ] = new DamagedDoctorCloth();
        labelDic[ Label.FullPlated ] = new FullPlated();
        labelDic[ Label.Padding ] = new Padding();
        labelDic[ Label.Patient ] = new Patient();
        labelDic[ Label.Tshirts ] = new Tshirts();
        //Capsule Initiation
        labelDic[ Label.MorfinDrug ] = new MorfinDrug();
        labelDic[ Label.AdrenalineDrug ] = new AdrenalineDrug();
        labelDic[ Label.RingerSolution ] = new RingerSolution();
        labelDic[ Label.Can ] = new Can();
        labelDic[ Label.Water ] = new Water();
        labelDic[ Label.Bandage ] = new Bandage();
        labelDic[ Label.Medicine ] = new Medicine();
        labelDic[ Label.WhiteCard ] = new WhiteCard();
        labelDic[ Label.BlackCard ] = new BlackCard();
        labelDic[ Label.YellowCard ] = new YellowCard();
        labelDic[ Label.CaffeinCapsule1 ] = labelDic[ Label.CaffeinCapsule2 ] = labelDic[ Label.CaffeinCapsule3 ] = new CaffeinCapsule();
        labelDic[ Label.CureAll1 ] = labelDic[ Label.CureAll2 ] = labelDic[ Label.CureAll3 ] = new CureAll();
        labelDic[ Label.Hallucinogen1 ] = labelDic[ Label.Hallucinogen2 ] = labelDic[ Label.Hallucinogen3 ] = new Hallucinogen();
        labelDic[ Label.LiquidFlameMedicine1 ] = labelDic[ Label.LiquidFlameMedicine2 ] = labelDic[ Label.LiquidFlameMedicine3 ] = new LiquidFlameMedicine();
        labelDic[ Label.Painkiller1 ] = labelDic[ Label.Painkiller2 ] = labelDic[ Label.Painkiller3 ] = new Painkiller();
        labelDic[ Label.PoisonCapsule1 ] = labelDic[ Label.PoisonCapsule2 ] = labelDic[ Label.PoisonCapsule3 ] = new PoisonCapsule();
        labelDic[ Label.Salt1 ] = labelDic[ Label.Salt2 ] = labelDic[ Label.Salt3 ] = new Salt();
        labelDic[ Label.Soup1 ] = labelDic[ Label.Soup2 ] = labelDic[ Label.Soup3 ] = new Soup();
        labelDic[ Label.VitaminTablet1 ] = labelDic[ Label.VitaminTablet2 ] = labelDic[ Label.VitaminTablet3 ] = new VitaminTablet();
    }


    //IsIdentified 함수 input parameter를 다양화 해야하는가.
    public void ItemIdentify( Label label ) {
        IsIdentified[ label ] = true;
        GameObject.Find( "Player" ).GetComponent<Player>().InventoryList.IdentifyAllTheInventoryItem();
    }

    public bool GetItemIdentificationInfo( Label label ) {
        return IsIdentified[ label ];
    }
    /** 아이템을 position 에 놓는다.
     */
    public void DropItem( MapTile maptile ) {
        //foreach( ItemCategory gObject in maptile.itemList ) {

        Vector2 nowPos = new Vector2( boardmanager.XPos * BoardManager.horizontalMovement, boardmanager.YPos * BoardManager.verticalMovement );

        Debug.Log( maptile.itemList.Count );
        switch( maptile.itemList.Count ) {
        case 0: return;
        case 1:
            InstantiateItem( maptile.itemList[ 0 ], monsterGenLocation[ 0 ] + nowPos );
            break;
        case 2:
            InstantiateItem( maptile.itemList[ 0 ], monsterGenLocation[ 1 ] + nowPos );
            InstantiateItem( maptile.itemList[ 1 ], monsterGenLocation[ 2 ] + nowPos );
            break;
        case 3:
            InstantiateItem( maptile.itemList[ 0 ], monsterGenLocation[ 3 ] + nowPos );
            InstantiateItem( maptile.itemList[ 1 ], monsterGenLocation[ 4 ] + nowPos );
            InstantiateItem( maptile.itemList[ 2 ], monsterGenLocation[ 5 ] + nowPos );
            break;
        default: break;
        }                                //}
    }

    /** 카드를 position 에 떨어트린다.
     */
    /**
     * It returns sprite about the label.
     */
    public Sprite LabelToSprite( Label label ) {
        if( label == Label.AutoHandgun ) {
            return weaponPrefabs[ 0 ].GetComponent<Image>().sprite;
        } else if( label == Label.BlackKnife ) {
            return weaponPrefabs[ 1 ].GetComponent<Image>().sprite;
        } else if( label == Label.Club ) {
            return weaponPrefabs[ 2 ].GetComponent<Image>().sprite;
        } else if( label == Label.Hammer ) {
            return weaponPrefabs[ 3 ].GetComponent<Image>().sprite;
        } else if( label == Label.Lighter ) {
            return weaponPrefabs[ 4 ].GetComponent<Image>().sprite;
        } else if( label == Label.Mess ) {
            return weaponPrefabs[ 5 ].GetComponent<Image>().sprite;
        } else if( label == Label.Nuckle ) {
            return weaponPrefabs[ 6 ].GetComponent<Image>().sprite;
        } else if( label == Label.SharpDagger ) {
            return weaponPrefabs[ 7 ].GetComponent<Image>().sprite;
        } else if( label == Label.Shock ) {
            return weaponPrefabs[ 8 ].GetComponent<Image>().sprite;
        } else if( label == Label.InjectorWeapon ) {
            return weaponPrefabs[ 9 ].GetComponent<Image>().sprite;
        } else if( label == Label.CleanDoctorCloth ) {
            return armorPrefabs[ 0 ].GetComponent<Image>().sprite;
        } else if( label == Label.DamagedDoctorCloth ) {
            return armorPrefabs[ 1 ].GetComponent<Image>().sprite;
        } else if( label == Label.FullPlated ) {
            return armorPrefabs[ 2 ].GetComponent<Image>().sprite;
        } else if( label == Label.Padding ) {
            return armorPrefabs[ 3 ].GetComponent<Image>().sprite;
        } else if( label == Label.Patient ) {
            return armorPrefabs[ 4 ].GetComponent<Image>().sprite;
        } else if( label == Label.Tshirts ) {
            return armorPrefabs[ 5 ].GetComponent<Image>().sprite;
        } else if( label == Label.Bandage ) {
            return expendablesPrefabs[ 0 ].GetComponent<Image>().sprite;
        } else if( label == Label.Can ) {
            return expendablesPrefabs[ 1 ].GetComponent<Image>().sprite;
        } else if( label == Label.Medicine ) {
            return expendablesPrefabs[ 2 ].GetComponent<Image>().sprite;
        } else if( label == Label.Water ) {
            return expendablesPrefabs[ 3 ].GetComponent<Image>().sprite;
        } else if( label == Label.CaffeinCapsule1 ) {
            return capsulePrefabs[ 0 ].GetComponent<Image>().sprite;
        } else if( label == Label.CureAll1 ) {
            return capsulePrefabs[ 1 ].GetComponent<Image>().sprite;
        } else if( label == Label.Hallucinogen1 ) {
            return capsulePrefabs[ 2 ].GetComponent<Image>().sprite;
        } else if( label == Label.LiquidFlameMedicine1 ) {
            return capsulePrefabs[ 3 ].GetComponent<Image>().sprite;
        } else if( label == Label.PoisonCapsule1 ) {
            return capsulePrefabs[ 4 ].GetComponent<Image>().sprite;
        } else if( label == Label.Salt1 ) {
            return capsulePrefabs[ 5 ].GetComponent<Image>().sprite;
        } else if( label == Label.VitaminTablet1 ) {
            return capsulePrefabs[ 6 ].GetComponent<Image>().sprite;
        } else if( label == Label.Painkiller1 ) {
            return capsulePrefabs[ 7 ].GetComponent<Image>().sprite;
        } else if( label == Label.Soup1 ) {
            return capsulePrefabs[ 8 ].GetComponent<Image>().sprite;
        } else if( label == Label.AdrenalineDrug ) {
            return injectorPrefabs[ 0 ].GetComponent<Image>().sprite;
        } else if( label == Label.MorfinDrug ) {
            return injectorPrefabs[ 1 ].GetComponent<Image>().sprite;
        } else if( label == Label.RingerSolution ) {
            return injectorPrefabs[ 2 ].GetComponent<Image>().sprite;
        } else if( label == Label.BlackCard ) {
            return cardPrefabs[ 0 ].GetComponent<Image>().sprite;
        } else if( label == Label.WhiteCard ) {
            return cardPrefabs[ 1 ].GetComponent<Image>().sprite;
        } else if( label == Label.YellowCard ) {
            return cardPrefabs[ 2 ].GetComponent<Image>().sprite;
        }
        return null;
    }

    /**
     * It mixes sprite of Capsule randomly and set it to prefabs.
     */
    void InitializePrefabsRandomly( GameObject[] Prefabs, Sprite[] Sprite ) {
        int len = Prefabs.Length;
        int[] PrefabIndex = new int[ len ];
        int[] SpriteIndex = new int[ len ];
        UnityEngine.Random.InitState( (int) System.DateTime.Now.Ticks );
        GenerateRandomSequence( ref PrefabIndex );
        GenerateRandomSequence( ref SpriteIndex );
        for( int i = 0; i < len; i++ )
            Prefabs[ PrefabIndex[ i ] ].GetComponent<Image>().sprite = Sprite[ SpriteIndex[ i ] ];
    }

    /** Subfunctions for InitializePrefabsRandomly function
     * \see InitializePrefabsRandomly
     */
    //{@
    public static void GenerateRandomSequence( ref int[] index ) {
        float[] weight = new float[ index.Length ];
        for( int i = 0; i < index.Length; i++ ) {
            index[ i ] = i;
            weight[ i ] = UnityEngine.Random.Range( 0, 100 ); //문제 생기면 겹치는 거 방지하는 코드 생성
        }
        for( int i = 0; i < index.Length; i++ )
            for( int j = 0; j < i; j++ ) {
                if( weight[ i ] < weight[ j ] ) {
                    Swap( ref weight[ i ], ref weight[ j ] );
                    Swap( ref index[ i ], ref index[ j ] );
                }
            }
    }
    static void Swap( ref float a, ref float b ) {
        float temp = a;
        a = b;
        b = temp;
    }
    static void Swap( ref int a, ref int b ) {
        int temp = a;
        a = b;
        b = temp;
    }





    public void InstantiateItem( ItemCategory iCat, Vector2 location ) {
        switch( iCat ) {
        /*무기*/
        case ItemCategory.AutoHandgun: Instantiate( weaponPrefabs[ 0 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.BlackKnife: Instantiate( weaponPrefabs[ 1 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Club: Instantiate( weaponPrefabs[ 2 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Hammer: Instantiate( weaponPrefabs[ 3 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Lighter: Instantiate( weaponPrefabs[ 4 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Mess: Instantiate( weaponPrefabs[ 5 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Nuckle: Instantiate( weaponPrefabs[ 6 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.SharpDagger: Instantiate( weaponPrefabs[ 7 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Shock: Instantiate( weaponPrefabs[ 8 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.InjectorWeapon: Instantiate( weaponPrefabs[ 9 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        /*방어구*/
        case ItemCategory.CleanDoctorCloth: Instantiate( armorPrefabs[ 0 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.DamagedDoctorCloth: Instantiate( armorPrefabs[ 1 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.FullPlated: Instantiate( armorPrefabs[ 2 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Padding: Instantiate( armorPrefabs[ 3 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Patient: Instantiate( armorPrefabs[ 4 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Tshirts: Instantiate( armorPrefabs[ 5 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        /*소모품*/
        case ItemCategory.Bandage: Instantiate( expendablesPrefabs[ 0 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Can: Instantiate( expendablesPrefabs[ 1 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Medicine: Instantiate( expendablesPrefabs[ 2 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Water: Instantiate( expendablesPrefabs[ 3 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        /*캡슐*/
        case ItemCategory.CaffeinCapsule: Instantiate( capsulePrefabs[ 0 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.CureAll: Instantiate( capsulePrefabs[ 1 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Hallucinogen: Instantiate( capsulePrefabs[ 2 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.LiquidFlameMedicine: Instantiate( capsulePrefabs[ 3 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.PoisonCapsule: Instantiate( capsulePrefabs[ 4 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Salt: Instantiate( capsulePrefabs[ 5 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.VitaminTablet: Instantiate( capsulePrefabs[ 6 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Painkiller: Instantiate( capsulePrefabs[ 7 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.Soup: Instantiate( capsulePrefabs[ 8 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        /*카드*/
        case ItemCategory.BlackCard: Instantiate( cardPrefabs[ 0 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.WhiteCard: Instantiate( cardPrefabs[ 1 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.YellowCard: Instantiate( cardPrefabs[ 2 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;

        /*주사기*/
        case ItemCategory.AdrenalineDrug: Instantiate( injectorPrefabs[ 0 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.MorfinDrug: Instantiate( injectorPrefabs[ 1 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;
        case ItemCategory.RingerSolution: Instantiate( injectorPrefabs[ 2 ], location, Quaternion.identity, GameObject.Find( "NEIUI" ).transform ); break;

        default: break;
        }

    }

    public static string DescriptionOfItem( ItemCategory itemCategory ) {
        switch( itemCategory ) {
        case ItemCategory.Lighter: return "라이터의 자체 공격력은 모든 무기를 통틀어 가장 약하지만, 적에게 잠깐 동안 불을 붙여 추가 피해를 줄 수 있습니다.";
        case ItemCategory.Nuckle: return "잘 늘어나는 장갑입니다. 끼고 있는 동안 엄청난 속도로 적을 공격할 수 있습니다.";
        case ItemCategory.InjectorWeapon: return "많은 이의 손을 거친 것 같은 피펫입니다. 적을 중독시킬 수 있습니다.";
        case ItemCategory.SharpDagger: return "말은 칼보다 무서운 법입니다. 이따금 적에게 치명적인 피해를 줄 수 있습니다.";
        case ItemCategory.Mess: return "누군가의 스마트폰입니다. 잠금이 걸려 있어 내용을 볼 수 없습니다.";
        case ItemCategory.Hammer: return "두꺼운 일반물리 서적입니다. 강력하지만 허기가 증가합니다.";
        case ItemCategory.Club: return "뾰족하게 깎은 각목입니다. 상당한 피해를 주지만 공격할 때마다 각목이 뭉툭해질 가능성이 있습니다.";
        case ItemCategory.Shock: return "휴대용 제세동기입니다. 강력한 전류를 흘려보내 적에게 큰 피해를 줌과 동시에 기절시킵니다. 보스는 기절에 면역이며 사용 횟수에 제한이 있습니다.";
        case ItemCategory.BlackKnife: return "누군가가 마구 두드린 흔적이 보이는 청축 키보드입니다. 이 키보드를 들고 있는 동안 키보드 워리어의 기운을 받아 제정신이 아닌 상태가 되지만, 매우 강력한 힘을 끌어낼 수 있습니다.";
        case ItemCategory.AutoHandgun: return "한 교수가 수많은 학생들을 '죽이는' 데에 사용했다 알려진 권총입니다. 보기만 해도 으스스합니다.";
        case ItemCategory.BloodJacket: return "가벼운 조끼입니다. 제정신이 아닌 상태에서는 조끼가 더 두껍게 느껴집니다.";
        case ItemCategory.Tshirts: return "통풍이 잘 되는 티셔츠로, 방어 성능은 거의 없습니다. 가볍기 때문에 배고픔을 느끼는 빈도가 줄어들 것입니다.";
        case ItemCategory.Patient: return "대학교에서 흔히 볼 수 있는 야구잠바입니다. 샌드위치를 먹을 때 더 많은 체력을 회복합니다.";
        case ItemCategory.DamagedDoctorCloth: return "이 실험복은 꽤 오래되었지만, 여전히 괜찮은 방어력을 제공합니다.";
        case ItemCategory.Padding: return "기숙사의 냉방이 너무 과하다 생각한 사람이 입던 패딩입니다. 공격을 효과적으로 막아 주지만, 많이 공격당하면 망가져서 사용할 수 없게 될 것입니다.";
        case ItemCategory.CleanDoctorCloth: return "눈부실 정도로 하얀 실험복입니다. 정신력을 유지하는 데에 도움이 됩니다.";
        case ItemCategory.FullPlated: return "도대체 이 장소에 왜 있는지 알 수 없는 중세풍 갑옷입니다. 엄청난 방어 성능을 제공하지만 그 무게로 인해 허기가 매우 빠르게 증가합니다.";
        case ItemCategory.CureAll: return "최근에 개발된 약으로, 하나만 먹으면 모든 병이 낫는다 알려져 있습니다. 먹으면 체력과 정신력을 모두 회복하고 각종 나쁜 상태에서 벗어납니다. 체력이 가득 찬 상태라면 최대 체력을 늘려줍니다.";
        case ItemCategory.Hallucinogen: return "이 환각제를 섭취하면 즉시 강렬한 환각에 빠집니다. 이미 환각을 경험중이라면 정신력을 조금 잃습니다. 적에게 환각제를 탄 물을 던져 혼란을 줄 수 있습니다.";
        case ItemCategory.LiquidFlameMedicine: return "엄청난 농도의 캡사이신이 들어 있는 알약입니다. 먹는 순간 자신과 방 안의 모든 적이 화염에 휩싸이게 됩니다. 적에게 매운 알약을 탄 물을 던지면 그 적만 불태울 수 있습니다.";
        case ItemCategory.CaffeinCapsule: return "각성 효과를 지닌 알약입니다. 먹으면 즉시 정신력ZSAzsa을 회복하고 일정 시간동안 신체 능력이 강화되지만, 그 대가로 지속적으로 정신력을 잃습니다.";
        case ItemCategory.VitaminTablet: return "물에 닿으면 거품이 많이 나고 새콤달콤한 맛을 내는 비타민입니다. 이유는 모르겠지만 캡슐에 들어 있습니다. 체력과 정신력을 조금씩 회복하지만 공격성이 잠깐동안 감소합니다. 적에게 발포 비타민을 탄 물을 던져 대상의 공격성을 낮출 수 있습니다.";
        case ItemCategory.Soup: return "따뜻한 물에 풀어서 바로 먹을 수 있는 알약형 수프입니다. 체력과 정신력을 회복하며 허기를 조금 달래줄 것입니다.";
        case ItemCategory.Painkiller: return "강렬한 통증을 잊을 수 있게 해 주는 알약입니다. 체력을 조금 회복하며, 부상이 심하다면 더 많은 체력을 회복합니다. 또한 환각에서 벗어나게 해줍니다.";
        case ItemCategory.PoisonCapsule: return "치명적이지는 않지만 생명체에게 악영향을 주는 독약입니다. 섭취하면 중독 상태에 빠집니다. 적에게 독약을 탄 물을 던져 중독시킬 수 있습니다.";
        case ItemCategory.Salt: return "이 괴상한 알약(?)에는 소금이 가득 들어있습니다. 정신력에 악영향을 주며 환각 상태라면 더욱 그 효과가 강해집니다. 적에게 소금물을 던져 방어를 무력화할 수 있습니다.";
        case ItemCategory.MorfinDrug: return "따뜻한 곰국이 들어 있는 병입니다. 마시면 정신력을 회복하며, 받는 피해가 줄어들지만 공격력이 감소합니다. 뒤집은 상태로 먹지 마세요!";
        case ItemCategory.AdrenalineDrug: return "시험기간에 많이 마시는 에너지 드링크입니다. 마시면 정신력을 약간 잃으며, 잠깐동안 엄청난 피해를 줄 수 있습니다.";
        case ItemCategory.RingerSolution: return "숙취 해소에 좋은 갈배 사이다입니다. 마시면 정신력을 조금 회복하며, 체력을 지속적으로 회복시킵니다.";
        case ItemCategory.Can: return "''L'' 버거보다 맛이 없습니다. 체력을 약간 회복하며 허기를 달래 줍니다.";
        case ItemCategory.Water: return "페트병에 든 물입니다. 마시면 정신력을 약간 회복하며, 몸에 뿌려 불을 끌 수도 있습니다.";
        case ItemCategory.Medicine: return "해독 작용을 하는 시럽이 든 작은 병입니다.";
        case ItemCategory.Bandage: return "튼튼한 붕대입니다. 상처에 감아서 출혈을 막을 수 있습니다.";
        case ItemCategory.WhiteCard: return "가장자리가 빛나는 하얀 키 카드입니다. 잠겨 있는 문을 열 수 있습니다.";
        case ItemCategory.BlackCard: return "가장자리가 빛나는 검은 키 카드입니다. 다음 층으로 가는 문을 열 수 있습니다.";
        case ItemCategory.YellowCard: return "가장자리가 빛나는 노란 키 카드입니다. 약품 창고나 비품실의 문을 열 수 있습니다.";
        default: return null;
        }
    }

    public static string NameOfItem( ItemCategory itemCategory ) {
        switch( itemCategory ) {
        case ItemCategory.Lighter: return "라이터";
        case ItemCategory.Nuckle: return "라텍스 장갑";
        case ItemCategory.InjectorWeapon: return "피펫";
        case ItemCategory.SharpDagger: return "팩트리어트 미사일";
        case ItemCategory.Mess: return "스마트폰";
        case ItemCategory.Hammer: return "'ㅗ' 일불만리 책";
        case ItemCategory.Club: return "각목";
        case ItemCategory.Shock: return "제세동기";
        case ItemCategory.BlackKnife: return "전투식 키보드";
        case ItemCategory.AutoHandgun: return "자동권총 'F'";
        case ItemCategory.BloodJacket: return "대학원생의 조끼";
        case ItemCategory.Tshirts: return "티셔츠";
        case ItemCategory.Patient: return "야구잠바";
        case ItemCategory.DamagedDoctorCloth: return "낡은 실험복";
        case ItemCategory.Padding: return "두꺼운 패딩";
        case ItemCategory.CleanDoctorCloth: return "깔끔한 실험복";
        case ItemCategory.FullPlated: return "판금 갑옷";
        case ItemCategory.CureAll: return "만병통치약";
        case ItemCategory.Hallucinogen: return "환각제";
        case ItemCategory.LiquidFlameMedicine: return "매운 알약";
        case ItemCategory.CaffeinCapsule: return "카페인 알약";
        case ItemCategory.VitaminTablet: return "발포 비타민";
        case ItemCategory.Soup: return "수프";
        case ItemCategory.Painkiller: return "진통제";
        case ItemCategory.PoisonCapsule: return "독약";
        case ItemCategory.Salt: return "소금";
        case ItemCategory.MorfinDrug: return "곰국";
        case ItemCategory.AdrenalineDrug: return "에너지 드링크";
        case ItemCategory.RingerSolution: return "갈배 사이다";
        case ItemCategory.Can: return "'S' 샌드위치";
        case ItemCategory.Water: return "물";
        case ItemCategory.Medicine: return "약품";
        case ItemCategory.Bandage: return "붕대";
        case ItemCategory.WhiteCard: return "하얀 키 카드";
        case ItemCategory.BlackCard: return "검은 키 카드";
        case ItemCategory.YellowCard: return "노란 키 카드";
        default: return null;
        }
    }
}
