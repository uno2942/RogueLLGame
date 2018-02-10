using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDialogBox : DialogBox {

    protected override void Init() {
        for(int i=0; i<buttons.Length; i++ ) {
            if( buttons[ i ].name == "Eat" )
                buttons[ i ].onClick.AddListener( EatCommand );
            else if( buttons[ i ].name == "Dump" )
                buttons[ i ].onClick.AddListener( DumpCommand );
            else
                buttons[ i ].onClick.AddListener( null );
        }
    }
    private void EatCommand() {

    }
}
