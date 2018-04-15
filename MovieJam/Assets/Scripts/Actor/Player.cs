using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Character {

	[SerializeField]
	private NavMeshAgent aiAgent;

	[SerializeField]
	private int movementSpeed = 8;

    //Unput :
     string leftTrigger;
     string rightTrigger;
     KeyCode aButton;
     KeyCode bButton;
     KeyCode xButton;
     KeyCode yButton;
     KeyCode rButton;
     string axis1X;
     string axis2X;
     string axis1Y;
     string axis2Y;
     bool mouseFollow = false;

    Vector3 direction = Vector3.zero;
    Vector3 angle = Vector3.zero;

    private Vector3 movementVec;
    public float bulletSpeed = 2;

    public bool invincible = true;
    public float delayBetweenHit = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        LimbDropped limb = collision.gameObject.GetComponent<LimbDropped>();
        if (limb != null ){
            if(limb.myTurn)
                TryAddLimb(limb);
        }
    }


    // Use this for initialization
    void Start () {
		movementVec = new Vector3 ();

		aiAgent.acceleration = movementSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		movementVec.x = Input.GetAxis(axis1X);
		movementVec.z = Input.GetAxis(axis1Y);

        //Here, lower the speed in function of your limbs
        if(listLimb[2] == null && listLimb[3] != null || listLimb[2] != null && listLimb[3] == null)
        {
            aiAgent.speed = (movementSpeed * 80/100);
        }
        else if(listLimb[2] == null && listLimb[3] == null)
        {
            aiAgent.speed = movementSpeed / 2;
        }

        changeAllAnimatorBool("Walk", movementVec != Vector3.zero);

        aiAgent.destination = aiAgent.transform.position + movementVec;

        angle = lookDirection();
        Quaternion rot = this.transform.GetChild(0).rotation;
        rot.eulerAngles = angle;
        this.transform.GetChild(0).rotation = rot;
            

        //Use members
        if (Input.GetKey(rButton) && Input.GetAxisRaw(leftTrigger) != 0) {
            print("Drop a left hand !");
        }
        else if (Input.GetAxis(leftTrigger) != 0)
        {
            print("Trigger Left");
        }
//        print(Input.GetAxis(leftTrigger) + "Fire = "+leftTrigger);
        if (Input.GetKey(rButton) && Input.GetAxisRaw(rightTrigger) != 0)
        {
            print("Drop a right hand !");
        }
        else if (Input.GetAxisRaw(rightTrigger) != 0)
        {
            print("Trigger Right");
        }
        
        if (Input.GetKeyDown(aButton))
        {
            print("Shoot");
            if (listLimb[0] != null)
            {
                listLimb[0].attack.attack( direction, bulletSpeed, true); 
            }
        }
        if (Input.GetKeyDown(bButton))
        {
            print("Chi");
            listLimb[0].attack.chi();


        }
        if (Input.GetKeyDown(xButton))
        {
            print("Dash");
            listLimb[0].attack.dash();

        }
        if (Input.GetKeyDown(yButton))
        {
            print("Y");

        }


    }

    public List<Animator> animators = new List<Animator>();

    public void changeAllAnimatorBool(string s, bool b)
    {
        foreach(Animator ani in animators)
        {
            ani.SetBool(s, b);
        }
    }

    public Vector3 lookDirection()
    {
        Vector3 res = Vector3.zero;
        if (mouseFollow)
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = GameManager.Instance.mainCamera.transform.position.y- this.transform.position.y;
            print("direction here = " + direction);
            Vector3 mouseWorldPos = GameManager.Instance.mainCamera.ScreenToWorldPoint(mousePoint);
            direction = mouseWorldPos - transform.position;
            direction.y = 0;
            direction.Normalize();
            print("direction      = " + direction);
        }
        else
        {
            direction.x = Input.GetAxis(axis2X);
            direction.z = Input.GetAxis(axis2Y);
            print("Joydirection = " + direction);
        }
        if(direction == Vector3.zero)
        {
            res = angle;
        }
        else
        {
            res = Vector3.up * Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);
        }
        return res;
    }



    public void changeController(int controllerNumber)
    {
        switch (controllerNumber)
        {
            case 1:
                leftTrigger = "Fire1";
                rightTrigger = "Fire1-r";
                aButton = KeyCode.Joystick1Button0;
                bButton = KeyCode.Joystick1Button1;
                xButton = KeyCode.Joystick1Button2;
                yButton = KeyCode.Joystick1Button3;
                /*rButton = KeyCode.Joystick1Button4;*/
                rButton = KeyCode.Joystick1Button5;
                axis1X = "Horizontal1";
                axis1Y = "Vertical1";
                axis2X = "Horizontal1-r";
                axis2Y = "Vertical1-r";
                break;
            case 2:
                leftTrigger = "Fire2";
                rightTrigger = "Fire2-r";
                aButton = KeyCode.Joystick2Button0;
                bButton = KeyCode.Joystick2Button1;
                xButton = KeyCode.Joystick2Button2;
                yButton = KeyCode.Joystick2Button3;
                /*yButton = KeyCode.Joystick2Button4;*/
                rButton = KeyCode.Joystick2Button5;
                axis1X = "Horizontal2";
                axis1Y = "Vertical2";
                axis2X = "Horizontal2-r";
                axis2Y = "Vertical2-r";
                break;
            case 3:
                leftTrigger = "Fire3";
                rightTrigger = "Fire3-r";
                aButton = KeyCode.Joystick3Button0;
                bButton = KeyCode.Joystick3Button1;
                xButton = KeyCode.Joystick3Button2;
                yButton = KeyCode.Joystick3Button3;
                /*yButton = KeyCode.Joystick2Button4;*/
                rButton = KeyCode.Joystick2Button5;
                axis1X = "Horizontal3";
                axis1Y = "Vertical3";
                axis2X = "Horizontal3-r";
                axis2Y = "Vertical3-r";
                break;
            case 4:
                leftTrigger = "Fire4";
                rightTrigger = "Fire4-r";
                aButton = KeyCode.Joystick4Button0;
                bButton = KeyCode.Joystick4Button1;
                xButton = KeyCode.Joystick4Button2;
                yButton = KeyCode.Joystick4Button3;
                /*yButton = KeyCode.Joystick2Button4;*/
                rButton = KeyCode.Joystick2Button5;
                axis1X = "Horizontal4";
                axis1Y = "Vertical4";
                axis2X = "Horizontal4-r";
                axis2Y = "Vertical4-r";
                break;
            default:
                leftTrigger = "LeftClick";
                rightTrigger = "RightClick";
                aButton = KeyCode.Keypad1;
                bButton = KeyCode.Keypad2;
                xButton = KeyCode.Keypad3;
                yButton = KeyCode.Keypad4;
                rButton = KeyCode.R;
                axis1X = "Horizontal";
                axis1Y = "Vertical";
                mouseFollow = true;
                break;
        } 


    }

    public override void Die()
    {
        print("Die");
    }
    public override void Hit()
    {
        life--;
        if(life <= 0)
        {
            Die();
        }
        else
        {
            int rand = Random.Range(0, (int)life);
            for (int i = 0; i < 4; i++)
            {
                if (listLimb[i] != null)
                {
                    if(rand == 0)
                    {
                        listLimb[i].drop();
                        listLimb[i] = null;
                    }
                }
            }
        }
    }

    public void TryAddLimb(LimbDropped limb)
    {
        int indexOfEnum = (int)limb.partPlace;
        if (listLimb[indexOfEnum] == null)
        {
            listLimb[indexOfEnum] = limb.clip(this);
        }
    }
}
