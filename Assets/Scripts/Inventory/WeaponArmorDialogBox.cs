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
            else
                buttons[ i ].onClick.AddListener( null );
            }
    }
    private void EquipOrUnequipCommand() {
        if( inventoryItem.isEquipped == false )
            inventoryItem.EquipCommand();
        else
            inventoryItem.UnequipCommand();
    }
}
