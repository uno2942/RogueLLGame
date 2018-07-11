using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** ItemManager's function is to control item in the game and give proper informations about item to player gameobject.
 */
public class ItemManager : MonoBehaviour {

    /**
     * \brief Item labels to distinguish
     * \details All the items should have a label, and the items in different floor should have different label \since the player can carry items from previous floor.
     */
    public enum Label {
        Empty, AutoHandgun, BlackKnife, Club, Hammer, Lighter, Mess, Nuckle, SharpDagger, Shock,
        BloodJacket, CleanDoctorCloth, DamagedDoctorCloth, FullPlated, Padding, Patient, Tshirts,
        CaffeinCapsule1, CureAll1, Hallucinogen1, LiquidFlameMedicine1, MuscleRelaxant1, PoisonCapsule1, Salt1, SleepingPill1, Soup1, Sugar1, VitaminTablet1,
        CaffeinCapsule2, CureAll2, Hallucinogen2, LiquidFlameMedicine2, MuscleRelaxant2, PoisonCapsule2, Salt2, SleepingPill2, Soup2, Sugar2, VitaminTablet2,
        CaffeinCapsule3, CureAll3, Hallucinogen3, LiquidFlameMedicine3, MuscleRelaxant3, PoisonCapsule3, Salt3, SleepingPill3, Soup3, Sugar3, VitaminTablet3,
        MorfinDrug, AdrenalineDrug, RingerSolution, Can, Water, Bandage, Medicine, DiscardedMedicine, WhiteCard, BlackCard, YellowCard, EndOfEnum
    };

    public enum ItemCategory {
        Empty, AutoHandgun, BlackKnife, Club, Hammer, Lighter, Mess, Nuckle, SharpDagger, Shock,
        BloodJacket, CleanDoctorCloth, DamagedDoctorCloth, FullPlated, Padding, Patient, Tshirts,
        CaffeinCapsule, CureAll, Hallucinogen, LiquidFlameMedicine, MuscleRelaxant,PoisonCapsule, Salt, SleepingPill, Soup, Sugar, VitaminTablet,
        MorfinDrug, AdrenalineDrug, RingerSolution, Can, Water, Bandage, Medicine, DiscardedMedicine, WhiteCard, BlackCard, YellowCard, EndOfEnum
    };
    
    public enum ItemType
    {
        Empty, Weapon, Armor, Expenables, Capsule, Injector, Card, EndOfEnum
    };

    public static ItemType LabelToType(Label lab)
    {
        if( lab == Label.Empty ) return ItemType.Empty;
        else if( lab == Label.AutoHandgun || lab == Label.BlackKnife || lab == Label.Club || lab == Label.Hammer || lab == Label.Lighter || lab == Label.Mess || lab == Label.Nuckle || lab == Label.SharpDagger || lab == Label.Shock ) return ItemType.Weapon;
        else if( lab == Label.BloodJacket || lab == Label.CleanDoctorCloth || lab == Label.DamagedDoctorCloth || lab == Label.FullPlated || lab == Label.Padding || lab == Label.Patient || lab == Label.Tshirts ) return ItemType.Armor;
        else if( lab == Label.MorfinDrug || lab == Label.AdrenalineDrug || lab == Label.RingerSolution || lab == Label.Can || lab == Label.Water || lab == Label.Bandage || lab == Label.Medicine || lab == Label.DiscardedMedicine ) return ItemType.Expenables;
        else if( lab == Label.BlackCard || lab == Label.YellowCard || lab == Label.WhiteCard ) return ItemType.Card;
        else return ItemType.Capsule;
    }

    public static ItemCategory LabelToCategory( Label label ) {
        if( label == Label.Empty ) return ItemCategory.Empty;
        else if( label == Label.AutoHandgun ) return ItemCategory.AutoHandgun;
        else if (label == Label.BlackKnife) return ItemCategory.BlackKnife;
        else if (label == Label.Club) return ItemCategory.Club;
        else if (label == Label.Hammer) return ItemCategory.Hammer;
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
        else if( label == Label.DiscardedMedicine ) return ItemCategory.DiscardedMedicine;
        else if( label == Label.WhiteCard ) return ItemCategory.WhiteCard;
        else if( label == Label.BlackCard ) return ItemCategory.BlackCard;
        else if( label == Label.YellowCard ) return ItemCategory.YellowCard;
        else if( label == Label.CaffeinCapsule1 || label == Label.CaffeinCapsule2 || label == Label.CaffeinCapsule3 ) return ItemCategory.CaffeinCapsule;
        else if( label == Label.CureAll1 || label == Label.CureAll2 || label == Label.CureAll3 ) return ItemCategory.CureAll;
        else if( label == Label.Hallucinogen1 || label == Label.Hallucinogen2 || label == Label.Hallucinogen3 ) return ItemCategory.Hallucinogen;
        else if( label == Label.LiquidFlameMedicine1 || label == Label.LiquidFlameMedicine2 || label == Label.LiquidFlameMedicine3 ) return ItemCategory.LiquidFlameMedicine;
        else if( label == Label.MuscleRelaxant1 || label == Label.MuscleRelaxant2 || label == Label.MuscleRelaxant3 ) return ItemCategory.MuscleRelaxant;
        else if( label == Label.PoisonCapsule1 || label == Label.PoisonCapsule2 || label == Label.PoisonCapsule3 ) return ItemCategory.PoisonCapsule;
        else if( label == Label.Salt1 || label == Label.Salt2 || label == Label.Salt3 ) return ItemCategory.Salt;
        else if( label == Label.SleepingPill1 || label == Label.SleepingPill2 || label == Label.SleepingPill3 ) return ItemCategory.SleepingPill;
        else if( label == Label.Soup1 || label == Label.Soup2 || label == Label.Soup3 ) return ItemCategory.Soup;
        else if( label == Label.Sugar1 || label == Label.Sugar2 || label == Label.Sugar3 ) return ItemCategory.Sugar;
        else if( label == Label.VitaminTablet1 || label == Label.VitaminTablet2 || label == Label.VitaminTablet3 ) return ItemCategory.VitaminTablet;
        else return ItemCategory.Empty; //Throw exception을 어떻게 하는지 모르겠어요.


    }

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
    public GameObject cardPrefab;

    public Sprite[] capsuleSprite;
    //@}

    public BoardManager boardmanager;
    public GameManager gamemanager;

    // Use this for initialization
    /**
     * Set all the label not identified and put sprite to prefabs.
     */
    void Start() {
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

        InitializePrefabsRandomly( capsulePrefabs, capsuleSprite );
    }

    // Update is called once per frame
    void Update() {

    }

    public Item LabelToItem(Label label) {
        return labelDic[ label ];
    }

    private void InitLabelDic( Dictionary<Label, Item> labelDic) {

        labelDic[ Label.AutoHandgun ] = new AutoHandgun();
        labelDic[ Label.BlackKnife ] = new BlackKnife();
        labelDic[ Label.Club ] = new Club();
        labelDic[ Label.Hammer ] = new Hammer();
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
        labelDic[ Label.DiscardedMedicine ] = new DiscardedMedicine();
        labelDic[ Label.WhiteCard ] = new WhiteCard();
        labelDic[ Label.BlackCard ] = new BlackCard();
        labelDic[ Label.YellowCard ] = new YellowCard();
        labelDic[ Label.CaffeinCapsule1 ] = labelDic[ Label.CaffeinCapsule2 ] = labelDic[ Label.CaffeinCapsule3 ] = new CaffeinCapsule();
        labelDic[ Label.CureAll1 ] = labelDic[ Label.CureAll2 ] = labelDic[ Label.CureAll3 ] = new CureAll();
        labelDic[ Label.Hallucinogen1 ] = labelDic[ Label.Hallucinogen2 ] = labelDic[ Label.Hallucinogen3 ] = new Hallucinogen();
        labelDic[ Label.LiquidFlameMedicine1 ] = labelDic[ Label.LiquidFlameMedicine2 ] = labelDic[ Label.LiquidFlameMedicine3 ] = new LiquidFlameMedicine();
        labelDic[ Label.MuscleRelaxant1 ] = labelDic[ Label.MuscleRelaxant2 ] = labelDic[ Label.MuscleRelaxant3 ] = new MuscleRelaxant();
        labelDic[ Label.PoisonCapsule1 ] = labelDic[ Label.PoisonCapsule2 ] = labelDic[ Label.PoisonCapsule3 ] = new PoisonCapsule();
        labelDic[ Label.Salt1 ] = labelDic[ Label.Salt2 ] = labelDic[ Label.Salt3 ] = new Salt();
        labelDic[ Label.SleepingPill1 ] = labelDic[ Label.SleepingPill2 ] = labelDic[ Label.SleepingPill3 ] = new SleepingPill();
        labelDic[ Label.Soup1 ] = labelDic[ Label.Soup2 ] = labelDic[ Label.Soup3 ] = new Soup();
        labelDic[ Label.Sugar1 ] = labelDic[ Label.Sugar2 ] = labelDic[ Label.Sugar3 ] = new Sugar();
        labelDic[ Label.VitaminTablet1 ] = labelDic[ Label.VitaminTablet2 ] = labelDic[ Label.VitaminTablet3 ] = new VitaminTablet();
    }



    //IsIdentified 함수 input parameter를 다양화 해야하는가.
    public void ItemIdentify( Label label ) {
        IsIdentified[ label ] = true;
    }
    
    public bool GetItemIdentificationInfo(Label label) {
        return IsIdentified[ label ];
    }
    
    public void DropItem(Vector2 position ) {
        int choose = Random.Range( 0, 5 );
        if( choose == 5 )
            choose = 4;
        if( choose < 2 )
            Instantiate( capsulePrefabs[ choose ], position, Quaternion.identity );
        else if( choose == 2 )
            Instantiate( weaponPrefabs[ 0 ], position, Quaternion.identity );
        else if(choose==3)
            Instantiate( expendablesPrefabs[ 0 ], position, Quaternion.identity );
        else if(choose==4)
            Instantiate( expendablesPrefabs[ 1 ], position, Quaternion.identity );
    }

    public void DropCard( Vector2 position ) {
        Instantiate( cardPrefab, position, Quaternion.identity );
    }
    /**
     * It returns sprite about the label.
     */
    public Sprite LabelToSprite(Label label)
    {
        if( label == Label.AutoHandgun ) {
            return weaponPrefabs[ 0 ].GetComponent<SpriteRenderer>().sprite;
        } else if( label == Label.CaffeinCapsule1 ) {
            return capsulePrefabs[ 0 ].GetComponent<SpriteRenderer>().sprite;
        } else if( label == Label.LiquidFlameMedicine1 ) {
            return capsulePrefabs[ 1 ].GetComponent<SpriteRenderer>().sprite;
        } else if( label == Label.Water ) {
            return expendablesPrefabs[ 0 ].GetComponent<SpriteRenderer>().sprite;
        } else if( label == Label.Can ) {
            return expendablesPrefabs[ 1 ].GetComponent<SpriteRenderer>().sprite;
        } else if( label == Label.BlackCard )
            return cardPrefab.GetComponent<SpriteRenderer>().sprite;
        return null;
    }

    /**
     * It mixes sprite of Capsule randomly and set it to prefabs.
     */
    void InitializePrefabsRandomly( GameObject[] Prefabs, Sprite[] Sprite ) {
        int len = Prefabs.Length;
        int[] PrefabIndex = new int[ len ];
        int[] SpriteIndex = new int[ len ];
        Random.InitState( (int) System.DateTime.Now.Ticks );
        GenerateRandomSequence( ref PrefabIndex );
        GenerateRandomSequence( ref SpriteIndex );
        for( int i = 0; i < len; i++ )
            Prefabs[ PrefabIndex[ i ] ].GetComponent<SpriteRenderer>().sprite = Sprite[ SpriteIndex[ i ] ];
    }

    /** Subfunctions for InitializePrefabsRandomly function
     * \see InitializePrefabsRandomly
     */
    //{@
    public static void GenerateRandomSequence( ref int[] index ) {
        float[] weight = new float[ index.Length ];
        for( int i = 0; i < index.Length; i++ ) {
            index[ i ] = i;
            weight[ i ] = Random.Range( 0, 100 ); //문제 생기면 겹치는 거 방지하는 코드 생성
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
    //@}
}
