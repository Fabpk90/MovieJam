using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public uint waveNumber;
	public List<SpawnPoint> spawnPoints;

	public List<Enemy> enemiesToSpawn;

	public uint monsterCount;

	public float cooldownSpawn;

	//ajouter une liste de monstres ?

	public void monsterIsDead()
	{
		monsterCount--;
		if (monsterCount == 0)
			GameManager.Instance.nextWave ();
	}

	public uint getMonsterRemaining()
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
