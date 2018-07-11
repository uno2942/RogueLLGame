using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDialogBox : DialogBox {
    Stair stair;
    protected override void Init() {
        stair = GameObject.Find( "Stair" ).GetComponent<Stair>();
        for( int i = 0; i < buttons.Length; i++ ) {
            if( buttons[ i ].name == "Yes" ) {
                buttons[ i ].onClick.AddListener( GoToNextFloor );
            } else if( buttons[ i ].name == "No" )
                buttons[ i ].onClick.AddListener( Cancel );
            else
                buttons[ i ].onClick.AddListener( null );
        }
    }
    private void GoToNextFloor() {
        stair.GotoNextFloor();
    }
    private void Cancel() {
        stair.Cancle();
    }

}
