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


    bool canShot = true;
    public GameObject bullet;
    public Transform gunPoint;
    public float cooldown;

    public Character charClippedOn ; 


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


    IEnumerator shot(Vector3 direction,float bulletSpeed, bool ally )
    {
        soundHandler.Instance.PlayShot();
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
        soundHandler.Instance.PlayKi();

    }
    public void dash()
    {
        soundHandler.Instance.PlayDash();
        charClippedOn.Dash(range * charClippedOn.transform.forward);
    }


	IEnumerator Cdash(Vector3 destination)
	{
		while(Vector3.Distance(charClippedOn.transform.position, destination) > 1f)
		{
			//print (Vector3.MoveTowards (charClippedOn.transform.position, destination, 1f));
			charClippedOn.transform.position =  Vector3.MoveTowards (charClippedOn.transform.position, destination, 1f);
			yield return new WaitForEndOfFrame();
		}

		charClippedOn.dashCollider.SetActive (false);

		yield return null;
	}
}
