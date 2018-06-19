﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskDialogBox : DialogBox {

    protected override void Init() {
        for( int i = 0; i < buttons.Length; i++ ) {
            if( buttons[ i ].name == "Drink" )
                buttons[ i ].onClick.AddListener( DrinkCommand );
            else if( buttons[ i ].name == "Throw" )
                buttons[ i ].onClick.AddListener( ThrowCommand );
            else if( buttons[ i ].name == "Dump" )
                buttons[ i ].onClick.AddListener( DumpCommand );
            else
                buttons[ i ].onClick.AddListener( null );
        }
    }
    private void DrinkCommand() {
        inventoryItem.DrinkCommand();
    }
    private void ThrowCommand() {
        inventoryItem.ThrowCommand();
    }
}
