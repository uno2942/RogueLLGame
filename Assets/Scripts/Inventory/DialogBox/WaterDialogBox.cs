using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDialogBox : DialogBox {

    protected override void Init() {
        for( int i = 0; i < buttons.Length; i++ ) {
            if( buttons[ i ].name == "Drink" )
                buttons[ i ].onClick.AddListener( DrinkCommand );
            else if( buttons[ i ].name == "Use" )
                buttons[ i ].onClick.AddListener( SpreadCommand );
            else if( buttons[ i ].name == "Dump" )
                buttons[ i ].onClick.AddListener( DumpCommand );
            else if( buttons[ i ].name == "Cancel" )
                buttons[ i ].onClick.AddListener( CancelCommand );
        }
    }
    private void DrinkCommand() {
        inventoryItem.UseCommand();
    }
    private void SpreadCommand() {
        inventoryItem.SpreadCommand();
    }
    
}
