using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArmorDialogBox : DialogBox {
    protected override void Init() {
       
            for( int i = 0; i < buttons.Length; i++ ) {
            if( buttons[ i ].name == "EquipandUnequip" ) {
                buttons[ i ].onClick.AddListener( EquipOrUnequipCommand ); 
            }
            else if( buttons[ i ].name == "Dump" )
                buttons[ i ].onClick.AddListener( DumpCommand );
            else if(buttons[i].name=="Cancel")
                buttons[ i ].onClick.AddListener( CancelCommand );
            }
    }
    private void EquipOrUnequipCommand() {
        if( GameObject.Find("Player").GetComponent<Player>().weaponindex == inventoryItem.Index || GameObject.Find( "Player" ).GetComponent<Player>().armorindex == inventoryItem.Index )
            inventoryItem.UnequipCommand();
        else
            inventoryItem.EquipCommand();
    }
    private void CancelCommand() {
        inventoryItem.CancelCommand();
    }
}
