using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shooter : Character
{

    private Vector3 PlayerPosition;
    float distance;

    [SerializeField]
    private NavMeshAgent aiShooter;
    bool idle = true;


    private Vector3 ShooterMove;
    private Vector3 DirectionShooter;
    
    private float DistanceFromPlayer = 5;

    // Use this for initialization
    void Start()
    {
        ShooterMove = aiShooter.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = GameManager.Instance.players[0].transform.position;
        distance = Vector3.Distance(PlayerPosition, gameObject.transform.position);
        if (distance <= DistanceFromPlayer)
        {
            idle = false;
            DirectionShooter = aiShooter.transform.position - PlayerPosition;
            DirectionShooter = DirectionShooter.normalized;
            DirectionShooter = DirectionShooter * DistanceFromPlayer;
            print(DirectionShooter);
            aiShooter.destination = transform.position + DirectionShooter;
        }
        else
        {
            idle = true;
        }
        
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
            //StartCoroutine(MaCoroutine());
        }
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }
}
