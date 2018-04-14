using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave  {

	[SerializeField]
	public List<SpawnPoint> spawnPoints;

	[SerializeField]
	public List<Enemy> enemiesToSpawn;
	[SerializeField]
	public int monsterCount;

	[SerializeField]
	public float cooldownSpawn;

	//ajouter une liste de monstres ?

	public void monsterIsDead()
	{
		monsterCount--;
		if (monsterCount == 0)
			GameManager.Instance.nextWave ();
	}

	public int getMonsterRemaining()
	{
		return monsterCount;
	}

	public SpawnPoint getAvaibleSpawnPoint()
	{
		foreach (SpawnPoint sp in spawnPoints) 
		{
			if (sp.isSpawnAvaible ())
				return sp;
		}

		return null;
	}
}
