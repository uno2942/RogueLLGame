using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : Expendable {
    public Medicine() {
        name = this.GetType().ToString();
    }
}
