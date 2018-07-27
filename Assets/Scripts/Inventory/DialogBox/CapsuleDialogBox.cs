using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleDialogBox : DialogBox {

    protected override void Init() {
        for( int i = 0; i < buttons.Length; i++ ) {
            if( buttons[ i ].name == "Eat" ) {
                buttons[ i ].onClick.AddListener( EatCapsuleCommand );
            }
            else if( buttons[ i ].name == "Throw" )
                buttons[ i ].onClick.AddListener( ThrowCommand );
            else if( buttons[ i ].name == "Dump" )
                buttons[ i ].onClick.AddListener( DumpCommand );
            else if( buttons[ i ].name == "Cancel" )
                buttons[ i ].onClick.AddListener( CancelCommand );
        }
    }
    private void EatCapsuleCommand() {
        inventoryItem.EatCapsuleCommand();
    }
    private void ThrowCommand() {
        inventoryItem.ThrowCommand();
    }
    private void CancelCommand() {
        inventoryItem.CancelCommand();
    }
}
