using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public enum Label {
        Empty, Sword, DelCan, Gown,
        Ethanol1stFloor, Water1stFloor, DiscardMedicine1stFloor, RingerSolution1stFloor, ParalyzingMedicine1stFloor, LiquidFlameMedicine1stFloor, AwakeningMedicine1stFloor, RelievingMedicine1stFloor, DetoxificatingMedicine1stFloor,
        Ethanol2ndFloor, Water2ndFloor, DiscardMedicine2ndFloor, RingerSolution2ndFloor, ParalyzingMedicine2ndFloor, LiquidFlameMedicine2ndFloor, AwakeningMedicine2ndFloor, RelievingMedicine2ndFloor, DetoxificatingMedicine2ndFloor,
        Ethanol3rdFloor, Water3rdFloor, DiscardMedicine3rdFloor, RingerSolution3rdFloor, ParalyzingMedicine3rdFloor, LiquidFlameMedicine3rdFloor, AwakeningMedicine3rdFloor, RelievingMedicine3rdFloor, DetoxificatingMedicine3rdFloor
    };

    public enum ItemType
    {
        Empty, Weapon, Armor, Food, Flask
    };

    public static ItemType LabelToType(Label lab)
    {
        if ( lab == Label.Empty ) return ItemType.Empty;
        else if ( lab == Label.Sword ) return ItemType.Weapon;
        else if ( lab == Label.DelCan ) return ItemType.Food;
        else if ( lab == Label.Gown ) return ItemType.Armor;
        else return ItemType.Flask;
    }
    private const int floorMax = 3;
    
    public GameObject[] weaponPrefabs; //Prefab과 Sprite가 일치하도록 넣어야 합니다.
    public GameObject[] armorPrefabs;
    public GameObject[] foodPrefabs;
    public GameObject[] flaskPrefabs;

    public Sprite[] weaponSprite;
    public Sprite[] armorSprite;
    public Sprite[] foodSprite;
    public Sprite[] flaskSprite;


    public BoardManager boardmanager;
    public GameManager gamemanager;

    Dictionary<Label, bool> IsIdentified = new Dictionary<Label, bool>();

    // Use this for initialization
    void Start() {
        boardmanager = GameObject.Find( "BoardManager" ).GetComponent<BoardManager>() as BoardManager;
        gamemanager = GameObject.Find( "GameManager" ).GetComponent<GameManager>() as GameManager;
        
        foreach(Label i in System.Enum.GetValues( typeof( Label ) ) ) {
            IsIdentified.Add( i, false );
        }

        for( int i = 0; i < weaponPrefabs.Length; i++ ) {
            Debug.Log( weaponPrefabs.Length );
            weaponPrefabs[ i ].GetComponent<SpriteRenderer>().sprite = weaponSprite[ i ];
        }
        for( int i = 0; i < armorPrefabs.Length; i++ )
            armorPrefabs[ i ].GetComponent<SpriteRenderer>().sprite = armorSprite[ i ];
        InitializePrefabsRandomly( foodPrefabs, foodSprite );
        InitializePrefabsRandomly( flaskPrefabs, flaskSprite );
    }

    // Update is called once per frame
    void Update() {

    }

    //IsIdentified 함수 input parameter를 다양화 해야하는가.
    void ItemIdentification( string ItemInfoName ) {

    }

    /*void ItemInfoIdentification(ItemInfo ItemInfo ) {

    }
    */
    public void DropItem(Vector2 position ) {
        Instantiate( weaponPrefabs[ 0 ], position, Quaternion.identity );
    }

    public Sprite LabelToSprite(Label label)
    {
        if(label == Label.Sword)
        {
            return weaponPrefabs [0].GetComponent<SpriteRenderer> ().sprite;
        }
        return null;
    }


    

    void InitializePrefabsRandomly( GameObject[] Prefabs, Sprite[] Sprite ) {
        int len = Prefabs.Length;
        int[] PrefabIndex = new int[ len ];
        int[] SpriteIndex = new int[ len ];
        GenerateRandomSequence( ref PrefabIndex );
        GenerateRandomSequence( ref SpriteIndex );
        for( int i = 0; i < len; i++ )
            Prefabs[ i ].GetComponent<SpriteRenderer>().sprite = Sprite[ i ];
    }

    void GenerateRandomSequence( ref int[] index ) {
        Random.InitState( (int) System.DateTime.Now.Ticks );
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

    void Swap(ref float a, ref float b) {
        float temp = a;
        a = b;
        b = temp;
    }
    void Swap( ref int a, ref int b ) {
        int temp = a;
        a = b;
        b = temp;
    }
}
