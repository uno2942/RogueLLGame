﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDialogBox : DialogBox {

    protected override void Init() {
        for( int i = 0; i < buttons.Length; i++ ) {
            if( buttons[ i ].name == "Take" ) {
                buttons[ i ].onClick.AddListener( TakeCapsuleCommand );
            } else if( buttons[ i ].name == "Throw" )
                buttons[ i ].onClick.AddListener( ThrowCommand );
            else if( buttons[ i ].name == "Dump" )
                buttons[ i ].onClick.AddListener( DumpCommand );
            else
                buttons[ i ].onClick.AddListener( null );
        }
    }
    
}