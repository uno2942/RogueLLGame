using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : Item {

    public virtual bool EattenBy( Player player ) {
        return true;
    }
    public virtual bool ThrownTo(Enemy enemy) {
        return true;
    }
}
