using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingLimb : MonoBehaviour {

	[SerializeField]
	private float range;

	[SerializeField]
	private float damage;

    public enum typeAttack
    {
        shoot,
        chi,
        dash,
    }

    public typeAttack typeAtt = typeAttack.shoot;

	public void playAnimation()
	{

	}

    public void attack(Vector3 direction, float bulletSpeed, bool ally)
    {
        switch (typeAtt)
        {
            case typeAttack.shoot:
                if(canShot)
                    StartCoroutine(shot(direction, bulletSpeed, ally));
                //tir // shot // chi
                break;
            case typeAttack.chi:
                chi();
                break;
            case typeAttack.dash:
                dash();
                break;
        }

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
    public void chi()
    {

    }
    public void dash()
    {

    }

}
