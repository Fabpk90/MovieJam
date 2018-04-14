using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour {

	enum EBodyParts
	{
		HEAD = 0,
		TORSO,
		RARM,
		LARM,
		RLEG,
		LLEG
	}

	[SerializeField]
	private EBodyParts partPlace;

	[SerializeField]
	private Animator animator;


	public Animator getAnimator()
	{
		return animator;
	}

	public void playDeathAnimation()
	{
		//plays the animation of the limb and then destry itself
		//should spawn a copy or itself somewhere in the map
	}
}
