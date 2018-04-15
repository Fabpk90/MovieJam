using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    [SerializeField]
    private GameObject playerGO;

	[SerializeField]
	public List<GameObject> enemyType;

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

		print ("lol");

		if (!gameStarted) 
		{
			gameStarted = true;
			spawnWave ();
		}
    }

	private void playerSpawned()
	{
		if (!gameStarted) 
		{
			gameStarted = true;
			spawnWave ();
		}
	}

	public void spawnWave()
	{
		if (actualWave < waves.Length) 
		{
			foreach (Wave.WaveSpawner ws in waves[actualWave].spawners) 
			{
				for (int i = 0; i < ws.nbToSpawn; i++) 
				{
					Instantiate (enemyType [ws.typeToSpawn], ws.spawnPoint.transform.position, Quaternion.identity);
				}
			}

			StartCoroutine(waitSecondsAndSpawnNextWave(waves[actualWave].cooldownWave));
		} else
			Debug.Log ("No more waves");
		
	}

	IEnumerator waitSecondsAndSpawnNextWave(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		actualWave++;
		spawnWave ();
		yield return null;
	}
}
