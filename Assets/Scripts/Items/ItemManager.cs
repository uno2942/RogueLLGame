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
        CaffeinCapsule, CureAll, Hallucinogen, LiquidFlameMedicine, Painkiller, PoisonCapsule, Salt,  Soup, VitaminTablet,
        MorfinDrug, AdrenalineDrug, RingerSolution, Can, Water, Bandage, Medicine, WhiteCard, BlackCard, YellowCard
    };
    /**
     * 아이템을 종류에 따라 크게 묶는 열거형이다.
     */
    public enum ItemType
    {
        Empty, Weapon, Armor, Expenables, Capsule, Injector, Card
    };

    public static ItemType LabelToType(Label lab)
    {
        if( lab == Label.Empty ) return ItemType.Empty;
        else if( lab == Label.AutoHandgun || lab == Label.BlackKnife || lab == Label.Club || lab == Label.Hammer || lab == Label.InjectorWeapon || lab == Label.Lighter || lab == Label.Mess || lab == Label.Nuckle || lab == Label.SharpDagger || lab == Label.Shock ) return ItemType.Weapon;
        else if( lab == Label.BloodJacket || lab == Label.CleanDoctorCloth || lab == Label.DamagedDoctorCloth || lab == Label.FullPlated || lab == Label.Padding || lab == Label.Patient || lab == Label.Tshirts ) return ItemType.Armor;
        else if( lab == Label.MorfinDrug || lab == Label.AdrenalineDrug || lab == Label.RingerSolution ) return ItemType.Injector;
        else if( lab == Label.Can || lab == Label.Water || lab == Label.Bandage || lab == Label.Medicine ) return ItemType.Expenables;
        else if( lab == Label.BlackCard || lab == Label.YellowCard || lab == Label.WhiteCard ) return ItemType.Card;
        else return ItemType.Capsule;
    }

    public static ItemType CategoryToType(ItemCategory category)
    {
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
        else if (label == Label.BlackKnife) return ItemCategory.BlackKnife;
        else if (label == Label.Club) return ItemCategory.Club;
        else if (label == Label.Hammer) return ItemCategory.Hammer;
        else if( label == Label.InjectorWeapon ) return ItemCategory.InjectorWeapon;
        else if (label == Label.Lighter) return ItemCategory.Lighter;
        else if (label == Label.Mess) return ItemCategory.Mess;
        else if (label == Label.Nuckle) return ItemCategory.Nuckle;
        else if (label == Label.SharpDagger) return ItemCategory.SharpDagger;
        else if (label == Label.Shock) return ItemCategory.Shock;
        else if ( label == Label.BloodJacket) return ItemCategory.BloodJacket;
        else if (label == Label.CleanDoctorCloth) return ItemCategory.CleanDoctorCloth;
        else if (label == Label.DamagedDoctorCloth) return ItemCategory.DamagedDoctorCloth;
        else if (label == Label.FullPlated) return ItemCategory.FullPlated;
        else if (label == Label.Padding) return ItemCategory.Padding;
        else if (label == Label.Patient) return ItemCategory.Patient;
        else if (label == Label.Tshirts) return ItemCategory.Tshirts;
        else if ( label == Label.MorfinDrug) return ItemCategory.MorfinDrug;
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
        else if( label == Label.Painkiller1 || label == Label.Painkiller2 || label == Label.Painkiller3 ) return ItemCategory.PoisonCapsule;
        else if( label == Label.PoisonCapsule1 || label == Label.PoisonCapsule2 || label == Label.PoisonCapsule3 ) return ItemCategory.PoisonCapsule;
        else if( label == Label.Salt1 || label == Label.Salt2 || label == Label.Salt3 ) return ItemCategory.Salt;
        else if( label == Label.Soup1 || label == Label.Soup2 || label == Label.Soup3 ) return ItemCategory.Soup;
        else if( label == Label.VitaminTablet1 || label == Label.VitaminTablet2 || label == Label.VitaminTablet3 ) return ItemCategory.VitaminTablet;
        else return ItemCategory.Empty; //Throw exception을 어떻게 하는지 모르겠어요.


    }

    public static Label CategoryToLabel(ItemCategory category, int floor)
    {
        return (Label)Enum.Parse(typeof(Label), category.ToString() + ((2 + floor) / 2).ToString());
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

        InitLabelDic(labelDic);
        foreach(Label i in System.Enum.GetValues( typeof( Label ) ) ) {
            if( LabelToType( i ) == ItemType.Capsule )
                IsIdentified.Add( i, false );
            else
                IsIdentified.Add( i, true );
        }
        IsIdentified[ Label.Empty ] = false;

        InitializePrefabsRandomly( capsulePrefabs, capsuleSprite );
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
    public Item LabelToItem(Label label) {
        return labelDic[ label ];
    }

    private void InitLabelDic( Dictionary<Label, Item> labelDic) {

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
    }
    
    public bool GetItemIdentificationInfo(Label label) {
        return IsIdentified[ label ];
    }
    /** 아이템을 position 에 놓는다.
     */
    
    public void DropItem(MapTile maptile) {
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
    public Sprite LabelToSprite(Label label)
    {
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
        } 
        
        else if( label == Label.CleanDoctorCloth ) {
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
        } 
        
        else if( label == Label.Bandage ) {
            return expendablesPrefabs[0].GetComponent<Image>().sprite;
        } else if( label == Label.Can ) {
            return expendablesPrefabs[ 1 ].GetComponent<Image>().sprite;
        } else if( label == Label.Medicine ) {
            return expendablesPrefabs[ 2 ].GetComponent<Image>().sprite;
        } else if( label == Label.Water ) {
            return expendablesPrefabs[ 3 ].GetComponent<Image>().sprite;
        } 
        
        else if( label == Label.CaffeinCapsule1 ) {
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
        }

        else if( label == Label.AdrenalineDrug ) {
            return injectorPrefabs[ 0 ].GetComponent<Image>().sprite;
        } else if( label == Label.MorfinDrug ) {
            return injectorPrefabs[ 1 ].GetComponent<Image>().sprite;
        } else if( label == Label.RingerSolution ) {
            return injectorPrefabs[ 2 ].GetComponent<Image>().sprite;
        }
        
        else if( label == Label.BlackCard ) {
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
    static void Swap(ref float a, ref float b) {
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


    //@}
}
