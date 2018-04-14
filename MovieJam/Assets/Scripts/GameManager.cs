using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    [SerializeField]
    private GameObject playerGO;

	private int actualWave;

    public Player[] players = new Player[4];

	[SerializeField]
	private List<Wave> waves;

	private int monsterSpawnedInThisWave = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && players[0] == null)
        {
            players[0] = Instantiate(playerGO, this.transform.position, this.transform.rotation).GetComponentInChildren<Player>();
        }
        
    }

	public void enemyIsDead()
	{
		waves[actualWave].monsterIsDead ();
	}

	public void nextWave()
	{
		actualWave++;

		if (actualWave < waves.Count) 
		{
			StartCoroutine (spawnWave ());
		} else
			Debug.Log ("No more waves");
	}

	/// <summary>
	/// Spawns the wave. And waits for all enemies to be dead(in another coroutine)
	/// </summary>
	/// <returns></returns>
	/// <param name="cooldownSpawn">Cooldown spawn.</param>
	IEnumerator spawnWave()
	{
		SpawnPoint sp = null;
		while (waves[actualWave].monsterCount != monsterSpawnedInThisWave) 
		{
			sp = waves [actualWave].getAvaibleSpawnPoint ();
			if (sp) 
			{
				Instantiate(waves[actualWave].enemiesToSpawn[Random.Range(0, waves[actualWave].enemiesToSpawn.Count - 1)]);
			}

			yield return new WaitForSeconds(waves[actualWave].cooldownSpawn);
		}
			
		yield return null;
	}
		

}
