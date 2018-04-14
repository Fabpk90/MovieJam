using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    [SerializeField]
    private GameObject playerGO;

    public Player[] players = new Player[4];

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
            players[0] = Instantiate(playerGO, this.transform.position, this.transform.rotation).GetComponent<Player>();
        }
    }
}
