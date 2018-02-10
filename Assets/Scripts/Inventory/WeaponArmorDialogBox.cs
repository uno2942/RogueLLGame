using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArmorDialogBox : DialogBox {

    public bool isEquipped;
    protected override void Init() {
       
            for( int i = 0; i < buttons.Length; i++ ) {
            if( buttons[ i ].name == "EquipandUnequip" ) {
                if( isEquipped == false )
                    buttons[ i ].onClick.AddListener( Equip );
                else
                    buttons[ i ].onClick.AddListener( Unequip );
            }
            else if( buttons[ i ].name == "Dump" )
                buttons[ i ].onClick.AddListener( DumpCommand );
            else
                buttons[ i ].onClick.AddListener( null );
            }
    }
    private void Equip() {

    }
    private void Unequip() {

    }
}
