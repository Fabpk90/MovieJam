using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character {

    [SerializeField]
    private NavMeshAgent aiEnemy;



    private Vector3 EnemyMove;
    // Use this for initialization
    void Start() {
        EnemyMove = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(GameManager.Instance.players[0].transform.position);
        aiEnemy.destination = GameManager.Instance.players[0].transform.position;


    }
}
