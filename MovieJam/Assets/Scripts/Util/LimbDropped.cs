using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbDropped : Limb {

    LimbClipped clipped;
    public bool myTurn = false;

    public Rigidbody rigidBody;
    public BoxCollider boxCollider;

    public bool canBeTaken = false;


    public void Awake()
    {
        clipped = GetComponent<LimbClipped>();
    }

    public void takenAuth()
    {
        canBeTaken = true;
    }

    public LimbClipped clip(Character parent)
    {
        clipped.charClippedOn = parent;
        clipped.attack.charClippedOn = clipped.charClippedOn;
        rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        boxCollider.isTrigger = true;
         myTurn = false;
        clipped.myTurn = true;
        this.transform.SetParent(parent.transform);

        animator.SetTrigger("clip");

        canBeTaken = false;
        Invoke("takenAuth", 0.5f);

        Vector3 forceV = Vector3.up * Random.Range(0, 28) + Vector3.forward * Random.Range(0, 28);
        rigidBody.AddForce(forceV.normalized * forceF);

        return clipped;

    }

    public float forceF = 25;
}
