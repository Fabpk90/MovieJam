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
        HEAD = 0,
		TORSO
		
	}

	[SerializeField]
	public EBodyParts partPlace;

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

    public void dropped()
    {
        transform.SetParent(null);
        
    }

    public void dropped(Vector3 position, Quaternion rotation)
    {
        transform.SetParent(null);

    }


}
