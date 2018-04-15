using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{

    private Vector3 PlayerPosition;

    [SerializeField]
    private NavMeshAgent aiEnemy;
    bool idle = false;

	private Wave spawnedWave;

    private Vector3 EnemyMove;
    // Use this for initialization
    void Start()
    {
        EnemyMove = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if (!idle)
        {
            PlayerPosition = GameManager.Instance.players[0].transform.position;
            //Debug.Log(GameManager.Instance.players[0].transform.position);

        }
        else
        {
            PlayerPosition = aiEnemy.transform.position;
        }
        aiEnemy.destination = PlayerPosition;
    }

    IEnumerator MaCoroutine()
    {
        idle = true;
        yield return new WaitForSeconds(10f);
        idle = false;
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player pl = collision.gameObject.GetComponentInChildren<Player>();
        if (pl != null)
        {
            StartCoroutine(MaCoroutine());
        }
    }

    public override void Die()
    {
        Destroy(this.gameObject);
    }

    public override void Hit()
    {
        life--;
        if (life <= 0)
        {
            Die();
        }

    }

}