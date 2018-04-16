using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Character : MonoBehaviour {

	protected uint life;
	protected float velocity;
    [SerializeField]
	protected LimbClipped[] listLimb = new LimbClipped[4];
    [SerializeField]
    protected Transform[] joints = new Transform[4];

    public GameObject dashCollider;

	public bool ally;

	abstract public void Die ();
    abstract public void Hit ();


	public void Dash(Vector3 destination)
	{
		//mettre la coroutine du dash ici, l'attack limb appel ça à chaque fois
		// box de collision (trigger) à setactive false
		//parenté au charac
		dashCollider.SetActive(true);

	}

	void OnTriggerEnter(Collider other)
	{
		Character charac = null;

		if((charac = other.GetComponent<Character>()) != null )
		{
			if(charac.ally != ally)
				charac.Hit ();
		}
	}
}
