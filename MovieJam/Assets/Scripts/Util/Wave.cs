using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave  {

	[System.Serializable]
	public class WaveSpawner
	{
		[SerializeField]
		public SpawnPoint spawnPoint;

		[SerializeField]
		public int typeToSpawn;

		[SerializeField]
		public int nbToSpawn;
	}



	[SerializeField]
	public List<WaveSpawner> spawners;

	[SerializeField, Tooltip("Le temps avant de lancer la prochaine wave")]
	public float cooldownWave;

}
