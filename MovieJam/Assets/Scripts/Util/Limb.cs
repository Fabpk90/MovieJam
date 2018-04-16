using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour {

	public enum EBodyParts
	{
        LARM,
        RARM,
        LLEG,
        RLEG,
        HEAD = 5,
		TORSO
		
	}

	[SerializeField]
	public EBodyParts partPlace;

	[SerializeField]
	protected Animator animator;


	public Animator getAnimator()
	{
		return animator;
	}
}
