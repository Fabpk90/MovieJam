using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbDropped : Limb {

    LimbClipped clipped;
    public bool myTurn = false;

    public Rigidbody rigidBody;
    public BoxCollider boxCollider;


    public void Awake()
    {
        clipped = GetComponent<LimbClipped>();
    }

    public LimbClipped clip(Character parent)
    {
        rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        boxCollider.isTrigger = true;
         myTurn = false;
        clipped.myTurn = true;
        this.transform.SetParent(parent.transform);
        return clipped;

    }
}
