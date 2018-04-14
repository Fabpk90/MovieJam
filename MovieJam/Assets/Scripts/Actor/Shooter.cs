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

    public float Cooldown = 0.5f;
    public float bulletSpeed = 2;   
    public bool CanShoot = true;
    public GameObject bullet;
    public Transform gunPoint;

    [SerializeField]
    private float DistanceFromPlayer = 10;

    // Use this for initialization
    void Start()
    {
        ShooterMove = aiShooter.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.players[0] != null)
        {
            PlayerPosition = GameManager.Instance.players[0].transform.position;
            distance = Vector3.Distance(PlayerPosition, gameObject.transform.position);
            if (distance <= DistanceFromPlayer)
            {
                idle = false;
                DirectionShooter = aiShooter.transform.position - PlayerPosition;
                DirectionShooter = DirectionShooter.normalized;
                DirectionShooter = DirectionShooter * DistanceFromPlayer;
//                print(DirectionShooter);
                aiShooter.destination = transform.position + DirectionShooter;
            }
            else if (idle == false)
            {
                print("Launch");
                idle = true;
                StartCoroutine(Shoot());
            }
        }
        
        
    }
    


    IEnumerator Shoot()
    {
        while (idle)
        {
            print("Shoot ! ");
            GameObject gO = Instantiate(bullet, gunPoint.transform.position, Quaternion.identity);
            Bullet bull = gO.GetComponent<Bullet>();
            Vector3 direction = (PlayerPosition - transform.position).normalized;
            CanShoot = false;
            yield return new WaitForSeconds(Cooldown);
            CanShoot = true;
        }
        print("Stop shooting to run");

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
    public override void Hit()
    {
        life--;
    }
}
