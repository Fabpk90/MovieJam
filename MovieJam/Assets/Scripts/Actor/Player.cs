using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Character {

	[SerializeField]
	private NavMeshAgent aiAgent;

    //Unput :
    public string leftTrigger;
    public string rightTrigger;
    public KeyCode aButton;
    public KeyCode bButton;
    public KeyCode xButton;
    public KeyCode yButton;
    public KeyCode rButton;
    public string axis1X;
    public string axis2X;
    public string axis1Y;
    public string axis2Y;
    public bool mouseFollow = false;

    private Vector3 movementVec;
    public float bulletSpeed = 2;

    private void OnCollisionEnter(Collision collision)
    {
        Limb limb = collision.gameObject.GetComponent<Limb>();
        if (limb != null ){
            print("Limb ! " + limb.name );
            TryAddLimb(limb);
        }
    }


    // Use this for initialization
    void Start () {
		movementVec = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		movementVec.x = Input.GetAxis(axis1X);
		movementVec.z = Input.GetAxis(axis1Y);

        //Here, lower the speed in function of your limbs


        aiAgent.destination = aiAgent.transform.position + movementVec;


        //Use members
        if(Input.GetKey(rButton) && Input.GetAxisRaw(leftTrigger) != 0) {
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

        if (Input.GetKeyDown(rButton))
        {
            print("R");

        }

        if (Input.GetKeyDown(aButton))
        {
            print("A");
            if (listLimb[0] != null)
            {
                Vector3 direction = lookDirection();
                listLimb[0].GetComponent<AttackingLimb>().attack( direction, bulletSpeed, true); 
            }
        }/*
        if (Input.GetKeyDown(bButton))
        {
            print("b");

        }
        if (Input.GetKeyDown(xButton))
        {
            print("X");

        }
        if (Input.GetKeyDown(yButton))
        {
            print("Y");

        }*/


    }

    public Vector3 lookDirection()
    {
        Vector3 res = Vector3.zero;
        if (mouseFollow)
        {
            
        }
        else
        {
            res.x = Input.GetAxis(axis1X);
            res.z = Input.GetAxis(axis1Y);
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
        throw new System.NotImplementedException();
    }
    public override void Hit()
    {
        life--;
        if(life == 0)
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
                        listLimb[i].dropped(/*position dans tableau*/transform.position,Quaternion.identity);
                        listLimb[i] = null;
                    }
                }
            }
        }
    }

    public void TryAddLimb(Limb limb)
    {
        int indexOfEnum = (int)limb.partPlace;
        if (listLimb[indexOfEnum] == null)
        {
            listLimb[indexOfEnum] = limb;
        }
    }
}
