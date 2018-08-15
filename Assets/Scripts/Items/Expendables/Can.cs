using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : Expendable {

    public Can() {
        name = this.GetType().ToString();
    }
    //set은 private
}
