using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    public Camera mainCamera;

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

    public Animator startImage;
    public Animator gameOver;

    private bool gameStarted = false;
    public bool gameFinished = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (reloadOk)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
            StartCoroutine(createNewPlayer(-1));
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && !controllerTaken.Contains(1))
        {
            controllerTaken.Add(1);
            StartCoroutine(createNewPlayer(1));
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button0) && !controllerTaken.Contains(2))
        {
            controllerTaken.Add(2);
            StartCoroutine(createNewPlayer(2));
        }
        if (Input.GetKeyDown(KeyCode.Joystick3Button0) && !controllerTaken.Contains(3))
        {
            controllerTaken.Add(3);
            StartCoroutine(createNewPlayer(3));
        }
        if (Input.GetKeyDown(KeyCode.Joystick4Button0) && !controllerTaken.Contains(4))
        {
            controllerTaken.Add(4);
            StartCoroutine( createNewPlayer(4));
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Quit");
            Application.Quit();
        }




    }

    public IEnumerator createNewPlayer(int controller)
    {
        startImage.SetTrigger("Start");
        if (numberOfPlayer == 0)
        {
            soundHandler.Instance.ChangeMusic();
            yield return new WaitForSeconds(1f);
        }
        Player plInst = Instantiate(playerGO, this.transform.position, this.transform.rotation).GetComponentInChildren<Player>();
        plInst.changeController(controller);

        players[numberOfPlayer] = plInst;

        Invoke("playerSpawned", 4.5f);
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

    public int herosDead = 0;

    public void HerosDie()
    {
        herosDead++;
        if(herosDead == controllerTaken.Count)
        {
            GameOver();
        }
    }
    public void HerosRevive()
    {
        herosDead--;
    }
    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        Invoke("canReload",2);
    }

    public bool reloadOk = false;
    public void canReload()
    {
        reloadOk = true;
    }


    IEnumerator waitSecondsAndSpawnNextWave(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		actualWave++;
		spawnWave ();
		yield return null;
	}
}
