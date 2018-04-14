using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingLimb : Limb {

	[SerializeField]
	private float range;

	[SerializeField]
	private float damage;

	public void playAnimation()
	{

	}

    public void attack(Vector3 direction, float bulletSpeed, bool ally)
    {
       StartCoroutine( shot(direction, bulletSpeed, ally));
        //tir // shot // chi

    }

    bool canShot = true;
    public GameObject bullet;
    public Transform gunPoint;
    public float cooldown;

    IEnumerator shot(Vector3 direction,float bulletSpeed, bool ally )
    {
        print("Shoot ! ");
        GameObject gO = Instantiate(bullet, gunPoint.transform.position, Quaternion.identity);
        Bullet bull = gO.GetComponent<Bullet>();
        bull.init(direction, bulletSpeed, ally);
        canShot = false;
        yield return new WaitForSeconds(cooldown);
        canShot = true;
    }
    void chi()
    {

    }
    void dash()
    {

    }

}
