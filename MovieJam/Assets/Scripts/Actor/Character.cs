using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Character : MonoBehaviour {

	protected uint life;
	protected float velocity;
	protected Limb[] listLimb = new Limb[4];

	abstract public void Die ();
    abstract public void Hit ();
}
