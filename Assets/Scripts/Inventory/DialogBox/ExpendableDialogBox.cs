using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpendableDialogBox : DialogBox {

    protected override void Init() {
        for(int i=0; i<buttons.Length; i++ ) {
            if( buttons[ i ].name == "Use" )
                buttons[ i ].onClick.AddListener( UseCommand );
            else if( buttons[ i ].name == "Dump" )
                buttons[ i ].onClick.AddListener( DumpCommand );
            else if( buttons[ i ].name == "Cancel" )
                buttons[ i ].onClick.AddListener( CancelCommand );
        }
    }
    private void UseCommand() {
        inventoryItem.UseCommand();
    }
    private void CancelCommand() {
        inventoryItem.CancelCommand();
    }
}
