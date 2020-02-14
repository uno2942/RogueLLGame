using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectorDialogBox : DialogBox {

    protected override void Init() {
        for( int i = 0; i < buttons.Length; i++ ) {
            if( buttons[ i ].name == "Inject" )
                buttons[ i ].onClick.AddListener( InjectCommand );
            else if( buttons[ i ].name == "Dump" )
                buttons[ i ].onClick.AddListener( DumpCommand );
            else
                buttons[ i ].onClick.AddListener( CancelCommand );
        }
    }
    private void InjectCommand() {
        inventoryItem.InjectCommand();
    }
}
