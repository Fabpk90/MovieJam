using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Character {

	[SerializeField]
	private NavMeshAgent aiAgent;



	private Vector3 movementVec;
	// Use this for initialization
	void Start () {
		movementVec = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		movementVec.x = Input.GetAxis("Horizontal");
		movementVec.z = Input.GetAxis("Vertical");

		

		aiAgent.destination = aiAgent.transform.position + movementVec;
	}
}
