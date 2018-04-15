using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbClipped : Limb {

    LimbDropped dropped;
    public bool myTurn = true;
    public AttackingLimb attack;

    public void Awake()
    {
        dropped = GetComponent<LimbDropped>();
    }

    public LimbDropped drop()
    {
        myTurn = false;
        dropped.myTurn = true;
        dropped.rigidBody.constraints = RigidbodyConstraints.None;
        dropped.boxCollider.isTrigger = false;
        this.transform.SetParent(null);
        return dropped;

    }

}
