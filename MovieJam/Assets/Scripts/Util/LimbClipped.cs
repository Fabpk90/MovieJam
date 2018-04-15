using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbClipped : Limb {

    LimbDropped dropped;
    public AttackingLimb attack;

    public LimbDropped drop()
    {
        return dropped;

    }

}
