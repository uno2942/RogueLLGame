using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * \brief 플레이어가 가지는 인벤토리를 관리하는 클래스
 */
public class Inventory {

    // Use this for initialization
    /** The size of inventory is 12.
     */
    public int size = 12;
    public bool isDialogBoxOn;
    public bool InjecCommuni;
    public bool MedicineCommuni;
    /**
     * Note that *inventoryItemPregab is for background of inventory, not for item prefab*.
     */
    private GameObject inventoryItemPrefab;
    private RectTransform InventoryTransform;
    private Dictionary<int, int> numberOfSameItems;
    /**
     * It is to distinguish the item contained in inventory.
     */
    private ItemManager.Label [] labelList;
    private GameObject [] inventoryObject;
    public Weapon[] weapons;
    public Armor[] armors;
    /**
     * It contains itemManager gameObject in the scene.
     */
    public ItemManager itemManager;

    public ItemManager.Label [] LabelList
    {
        get
        {
            return labelList;
        }
    }

    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /**
     * \brief It initialise the basic setting of inventory.
     * \details It initiate inventoryObject with empty items and put each objects to appropriate location.
     * To avoid the Monobehavior initializing process which uses start() function, we uses this function and invoke it in player class.(This is unnessesary legacy.)
     * \see Player::Start
     */
    public void Initialize()
    {
        weapons = new Weapon[ 12 ];
        armors = new Armor[ 12 ];
        InventoryTransform = GameObject.Find( "InventoryPanel" ).GetComponent<RectTransform>();
        inventoryItemPrefab = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath( "Assets/Prefabs/InventoryItem.prefab", typeof( GameObject ) );
        labelList = new ItemManager.Label [size];
        inventoryObject = new GameObject [size];
        itemManager = GameObject.Find ("ItemManager").GetComponent<ItemManager> ();
        numberOfSameItems = new Dictionary<int, int>();
        for ( int i = 0; i < 6; i++ )
        {
            inventoryObject [i] = GameObject.Instantiate (inventoryItemPrefab, InventoryTransform );
            labelList [i] = ItemManager.Label.Empty;
            numberOfSameItems.Add( i, 0 );
        }
        for( int i = 0; i < 6; i++ ) {
            inventoryObject[ i + 6 ] = GameObject.Instantiate( inventoryItemPrefab, InventoryTransform );
            labelList[ i + 6 ] = ItemManager.Label.Empty;
            numberOfSameItems.Add( i + 6, 0 );
        }

    }

        /**
     * When player add an item, it find the location where the item should be and put the item by assigning appropriate sprite and label.
     * The sprite for the label is taken by the function itemManager.LabelToSprite.
     * \param label When player licked item, the gameObject calls this function with label of the item.
     * \see Player::PickItem(ItemManager.Label) and
     * \see Item::OnMouseUpAsButton
     * There is a debug log function.
     */
    public bool AddItem(ItemManager.Label label, GameObject gObject)
    {
        int location;
        for ( location = 0; location < size; location++ )
        {
            if ( labelList [location] == ItemManager.Label.Empty || labelList[location]==label) break;
        }

        if ( location < size )
        {
            if( labelList[ location ] == ItemManager.Label.Empty ) {
                labelList[ location ] = label;
                inventoryObject[ location ].GetComponent<Image>().sprite = gObject.GetComponent<Image>().sprite;
                inventoryObject[ location ].GetComponent<InventoryItem>().Index = location; //남길지 말지 

                if( itemManager.GetItemIdentificationInfo( labelList[ location ] ) )
                    inventoryObject[ location ].GetComponentInChildren<UnityEngine.UI.Text>().text = labelList[ location ].ToString();
                numberOfSameItems[ location ] = 1;
                return true;
            } 
            else if( label == labelList[ location ] && ItemManager.LabelToType( labelList[ location ] ) != ItemManager.ItemType.Weapon && ItemManager.LabelToType( labelList[ location ] ) != ItemManager.ItemType.Armor ) {
                numberOfSameItems[ location ]++;
                return true;
            } 
            else
                return false;

        }
        else
        {
            Debug.Log ("인벤토리가 꽉 찼다.");
            return false;
        }
    }

    public bool AddItem( ItemManager.Label label) {
        int locationEmpty;
        int locationSameLabel;
        for( locationEmpty = 0; locationEmpty < size; locationEmpty++ ) {
            if( labelList[ locationEmpty ] == ItemManager.Label.Empty ) break;
        }

        for( locationSameLabel = 0; locationSameLabel < size; locationSameLabel++ ) {
            if( labelList[ locationSameLabel ] == label ) break;
        }

        if( locationEmpty < size || locationSameLabel < size ) {
            if( locationSameLabel < size && ItemManager.LabelToType( labelList[ locationSameLabel ] ) != ItemManager.ItemType.Armor && ItemManager.LabelToType( labelList[ locationSameLabel ] ) != ItemManager.ItemType.Weapon ) {
                numberOfSameItems[ locationSameLabel ]++;
                return true;
            }
            else if( locationEmpty < size ) {
                labelList[ locationEmpty ] = label;
                inventoryObject[ locationEmpty ].GetComponent<Image>().sprite = itemManager.LabelToSprite( label );
                inventoryObject[ locationEmpty ].GetComponent<InventoryItem>().Index = locationEmpty;

                if( itemManager.GetItemIdentificationInfo( labelList[ locationEmpty ] ) )
                    inventoryObject[ locationEmpty ].GetComponentInChildren<UnityEngine.UI.Text>().text = labelList[ locationEmpty ].ToString();
                numberOfSameItems[ locationEmpty ] = 1;

                if( ItemManager.LabelToType( labelList[ locationEmpty ] ) == ItemManager.ItemType.Armor ) {
                    armors[ locationEmpty ] = NewArmor( label );
                    armors[ locationEmpty ].setRank( ItemManager.LabelToCategory(label) );
                    armors[ locationEmpty ].SetMaxDefbyRank( armors[locationEmpty].rank );
                } else if( ItemManager.LabelToType( labelList[ locationEmpty ] ) == ItemManager.ItemType.Weapon ) {
                    weapons[ locationEmpty ] = NewWeapon( label );
                    weapons[ locationEmpty ].setRank( ItemManager.LabelToCategory( label ) );
                    weapons[ locationEmpty ].SetMaxAtkbyRank( weapons[ locationEmpty ].rank );
                }
                return true;
            }
            return false;
            }
        else {
            Debug.Log( "인벤토리가 꽉 찼다." );
            return false;
        }
    }

    private Weapon NewWeapon(ItemManager.Label label ) {
        switch( label ) {
        case ItemManager.Label.AutoHandgun: return new AutoHandgun();
        case ItemManager.Label.BlackKnife: return new BlackKnife();
        case ItemManager.Label.Club: return new Club();
        case ItemManager.Label.Hammer: return new Hammer();
        case ItemManager.Label.Lighter: return new Lighter();
        case ItemManager.Label.InjectorWeapon: return new InjectorWeapon();
        case ItemManager.Label.Mess: return new Mess();
        case ItemManager.Label.Nuckle: return new Nuckle();
        case ItemManager.Label.Shock: return new Shock();
        case ItemManager.Label.SharpDagger: return new SharpDagger();
        default: return null;
    }
    }


    private Armor NewArmor( ItemManager.Label label ) {
        switch( label ) {
        case ItemManager.Label.BloodJacket: return new BloodJacket();
        case ItemManager.Label.CleanDoctorCloth: return new CleanDoctorCloth();
        case ItemManager.Label.DamagedDoctorCloth: return new DamagedDoctorCloth();
        case ItemManager.Label.FullPlated: return new FullPlated();
        case ItemManager.Label.Padding: return new Padding();
        case ItemManager.Label.Patient: return new Patient();
        case ItemManager.Label.Tshirts: return new Tshirts();
        default: return null;
        }
    }
    /** 
     * 인벤토리에서 index에 해당하는 아이템을 지운다.
     */
    public void DeleteItem(int index) {
        numberOfSameItems[ index ]--;
        if( numberOfSameItems[ index ] == 0 ) {
            weapons[ index ] = null;
            armors[ index ] = null;
            inventoryObject[ index ].GetComponent<Image>().sprite = inventoryItemPrefab.GetComponent<Image>().sprite;
            labelList[ index ] = ItemManager.Label.Empty;
            inventoryObject[ index ].GetComponentInChildren<UnityEngine.UI.Text>().text = "Empty";
        }
    }

    /** 해당 라벨에 해당하는 아이템이 있는지 확인한다.
     */
    public bool CheckItem(  ItemManager.Label _label ) {
        for(int i=0; i<size; i++ ) {
            if( _label == labelList[ i ] )
                return true;
        }
        return false;
    }
    /** 해당 카테고리에 해당하는 아이템이 있는지 확인한다.
     */
    public bool CheckItem(ItemManager.ItemCategory itemCategory ) {
        for( int i = 0; i < size; i++ ) {
            if( itemCategory == ItemManager.LabelToCategory( labelList[ i ] ) )
                return true;
        }
        return false;
    }

    /** 인텍스에 해당하는 아이템의 라벨을 가져오는 함수
     */
    public ItemManager.Label GetLabel( int index ) {
        return LabelList[ index ];
    }

    /** 아이템 라벨에 해당하는 가장 작은 인덱스를 가져오는 함수
     */
    public int Getindex(ItemManager.Label label ) {
        for( int i = 0; i < size; i++ ) {
            if( label == labelList[ i ] )
                return i;
        }
        return -1;
    }
    /**
     * 인벤토리에 있는 모든 아이템의 감정 상태를 확인하고, 감정 되어 있을 경우, 인벤토리 아이템 밑의 줄에 아이템 이름을 띄운다.
     */
    public void IdentifyAllTheInventoryItem() {
        for( int i = 0; i < size; i++ ) {
            if( itemManager.GetItemIdentificationInfo( labelList[ i ] ) )
                inventoryObject[ i ].GetComponentInChildren<UnityEngine.UI.Text>().text = itemManager.LabelToItem( labelList[ i ] ).Name + "x" + numberOfSameItems[ i ];
            else if( labelList[ i ] != ItemManager.Label.Empty )
                inventoryObject[ i ].GetComponentInChildren<UnityEngine.UI.Text>().text = "???" + "x" + numberOfSameItems[ i ];
                }
    }
}

