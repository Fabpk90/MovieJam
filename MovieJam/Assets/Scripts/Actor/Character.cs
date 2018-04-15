using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Character : MonoBehaviour {

	protected uint life;
	protected float velocity;
    [SerializeField]
	protected LimbClipped[] listLimb = new LimbClipped[4];

	abstract public void Die ();
    abstract public void Hit ();
}
