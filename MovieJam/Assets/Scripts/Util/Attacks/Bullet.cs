using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Vector3 direction = Vector3.zero;
    float speed = 2;
    bool ally = true;


    private void OnTriggerEnter(Collider other)
    {
        Character charac = other.GetComponent<Character>();
        if (charac)
        {
            if(   (!ally && (other.GetComponent<Player>()!=null))      ||       (ally && (other.GetComponent<Player>()==null))   )
            {
                charac.Hit();
            }

        }
        kill();
    }


    public void init (Vector3 d, float s, bool a)
    {
        direction = d;
        speed = s;
        ally = a;
        Invoke("kill",12);
    }

    void kill()
    {
        CancelInvoke();
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * speed * Time.deltaTime);

	}

	public void attack()
	{

	}
}
