using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbClipped : Limb {

    LimbDropped dropped;
    public bool myTurn = true;
    public AttackingLimb attack;
    public Character charClippedOn;

    [Header("Animation")]
    public Transform myJoint;
    public Transform hisJoint;


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

        dropped.Launch();


        return dropped;

    }


    #region IK

    void LateUpdate()
    {
        if (!myTurn)
            return;

        if (myJoint == null || hisJoint == null)
            return;
        

        CalculateIK();
    }

    void CalculateIK()
    {
        //calcul difference
        Vector3 offset = myJoint.position - hisJoint.position;
        //applique difference
        this.transform.position -= offset;
        /*if (myJoint.position == hisJoint.position)
            print("Success !");*/
    }

    #endregion


}
