using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug : Item {

    public virtual bool DrunkBy( Player player ) {
        return true;
    }
    public virtual bool ThrownTo(Enemy enemy) {
        return true;
    }
}
