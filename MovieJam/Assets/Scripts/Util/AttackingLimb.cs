using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingLimb : MonoBehaviour {

	[SerializeField]
	private float range;

	[SerializeField]
	private float damage;


	private Character charClippedOn;
	private float yCorrection;

	void Awake()
	{
		//print (transform.parent.position);
		charClippedOn = GetComponentInParent<Character> ();
		print (charClippedOn.transform.position);
		yCorrection = charClippedOn.transform.position.y;
		print (yCorrection);
	}


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
    public void chi()
    {

    }
    public void dash()
    {
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
