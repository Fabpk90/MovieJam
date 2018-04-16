using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbClipped : Limb {

    LimbDropped dropped;
    public bool myTurn = true;
    public AttackingLimb attack;
    public Character charClippedOn;

    public void Awake()
    {
        dropped = GetComponent<LimbDropped>();
        if(attack != null)
            attack.charClippedOn = charClippedOn;
    }

    public LimbDropped drop()
    {
        myTurn = false;
        dropped.myTurn = true;
        dropped.rigidBody.constraints = RigidbodyConstraints.None;
        dropped.boxCollider.isTrigger = false;
        this.transform.SetParent(null);
        charClippedOn = null;
        return dropped;

    }

}
