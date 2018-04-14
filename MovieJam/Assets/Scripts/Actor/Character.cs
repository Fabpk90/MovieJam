using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Character : MonoBehaviour {

	protected uint life;
	protected float velocity;
	protected List<Limb> list;

	abstract public void Die ();
}
