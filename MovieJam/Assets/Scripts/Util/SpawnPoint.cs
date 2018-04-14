using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	public bool isSpawnAvaible()
	{
		RaycastHit[] hits;
		hits = Physics.SphereCastAll (transform.position, 5f, Vector3.up);

		foreach (RaycastHit hit in hits) 
		{
			if (hit.collider.gameObject.GetComponentInChildren<Character> ())
				return false;
		}

		return true;
	}
}
