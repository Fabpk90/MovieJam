using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dasher : Character
{

    private Vector3 PlayerPosition;
    float distance;

    [SerializeField]
    private NavMeshAgent aiDasher;
    bool idle = false;


    private Vector3 DasherMove;
    // Use this for initialization
    void Start()
    {
        DasherMove = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(GameManager.Instance.players[0].transform.position, aiDasher.transform.position);
        if (distance <= 10 && !idle)
        {
            StartCoroutine(MaCoroutineDash());

        }
        if (!idle)
        {
            PlayerPosition = GameManager.Instance.players[0].transform.position;
            //Debug.Log(GameManager.Instance.players[0].transform.position);

        }
        else
        {
            PlayerPosition = aiDasher.transform.position;
        }
        aiDasher.destination = PlayerPosition;
    }

    IEnumerator MaCoroutineDash()
    {
        aiDasher.speed = 40;
        aiDasher.acceleration = 25;
        yield return new WaitForSeconds(2f);
        aiDasher.speed = 2;
        aiDasher.acceleration = 8;
        idle = true;
        yield return new WaitForSeconds(2.5f);
        idle = false;
        yield return null;
    }

    IEnumerator MaCoroutineCollision()
    {
        idle = true;
        yield return new WaitForSeconds(3f);
        idle = false;
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player pl = collision.gameObject.GetComponentInChildren<Player>();
        if (pl != null)
        {
            StartCoroutine(MaCoroutineCollision());
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
