using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injector : Item {

    public virtual bool InjectedBy( Player player ) {
        return true;
    }
}
