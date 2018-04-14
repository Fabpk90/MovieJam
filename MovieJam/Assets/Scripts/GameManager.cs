using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    [SerializeField]
    private GameObject playerGO;

	private int actualWave = 0;

    public Player[] players = new Player[4];
    public int numberOfPlayer = 0;
    public List<int> controllerTaken = new List<int>(); //0 = keyboard n = gamepad N

	[SerializeField]
	private Wave[] waves;

	private int monsterSpawnedInThisWave = 0;

	private bool gameStarted = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

           Debug.Log( Input.GetJoystickNames().Length );
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {

        /*

        if (Input.GetKeyDown(KeyCode.Space) && players[0] == null)
        {
            players[0] = Instantiate(playerGO, this.transform.position, this.transform.rotation).GetComponentInChildren<Player>();
			playerSpawned ();
        }
        
    */
        if(Input.GetKeyDown(KeyCode.Space) && !controllerTaken.Contains(-1))
        {
            controllerTaken.Add(-1);
            createNewPlayer(-1);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && !controllerTaken.Contains(1))
        {
            controllerTaken.Add(1);
            createNewPlayer(1);
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button0) && !controllerTaken.Contains(2))
        {
            controllerTaken.Add(2);
            createNewPlayer(2);
        }
        if (Input.GetKeyDown(KeyCode.Joystick3Button0) && !controllerTaken.Contains(3))
        {
            controllerTaken.Add(3);
            createNewPlayer(3);
        }
        if (Input.GetKeyDown(KeyCode.Joystick4Button0) && !controllerTaken.Contains(4))
        {
            controllerTaken.Add(4);
            createNewPlayer(4);
        }





    }

    public void createNewPlayer(int controller)
    {
        Player plInst = Instantiate(playerGO, this.transform.position, this.transform.rotation).GetComponentInChildren<Player>();
        plInst.changeController(controller);

        players[numberOfPlayer] = plInst;
    }

	private void playerSpawned()
	{
		if (!gameStarted) 
		{
			gameStarted = true;
			nextWave ();
		}
	}

	public void enemyIsDead()
	{
		waves[actualWave].monsterIsDead ();
	}

	public void nextWave()
	{

		if (actualWave < waves.Length) 
		{
			StartCoroutine (spawnWave (waves[actualWave]));
		} else
			Debug.Log ("No more waves");

	}

	/// <summary>
	/// Spawns the wave. And waits for all enemies to be dead(in another coroutine)
	/// </summary>
	/// <returns></returns>
	/// <param name="cooldownSpawn">Cooldown spawn.</param>
	IEnumerator spawnWave(Wave wave)
	{
		SpawnPoint sp = null;

		while (wave.monsterCount != monsterSpawnedInThisWave) 
		{
			sp = wave.getAvaibleSpawnPoint ();
			if (sp)
			{
				Instantiate (wave.enemiesToSpawn [Random.Range (0, wave.enemiesToSpawn.Count)]);
				monsterSpawnedInThisWave++;
				yield return new WaitForSeconds(wave.cooldownSpawn);
			} else
				print ("rien trouver");

			yield return new WaitForSeconds(1f);

		}
			
		actualWave++;

		nextWave ();

		yield return null;
	}
		

}
