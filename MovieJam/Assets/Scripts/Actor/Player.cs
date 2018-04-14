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
    public string axis1X;
    public string axis2X;
    public string axis1Y;
    public string axis2Y;
    public bool mouseFollow = false;

    private Vector3 movementVec;
	// Use this for initialization
	void Start () {
		movementVec = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		movementVec.x = Input.GetAxis(axis1X);
		movementVec.z = Input.GetAxis(axis1Y);

        aiAgent.destination = aiAgent.transform.position + movementVec;

        //Use members
        if (Input.GetAxisRaw(leftTrigger) != 0)
        {

        }
        if (Input.GetAxisRaw(rightTrigger) != 0)
        {

        }

        //Drop members
        if (Input.GetKeyDown(aButton))
        {

        }
        if (Input.GetKeyDown(bButton))
        {

        }
        if (Input.GetKeyDown(xButton))
        {

        }
        if (Input.GetKeyDown(yButton))
        {

        }


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
                axis1X = "Horizontal1";
                axis1Y = "Vertical1";
                axis2X = "Horizontal1-r";
                axis2Y = "Vertical1-r";
                break;
            case 2:
                leftTrigger = "Fire2";
                rightTrigger = "Fire2-r";
                aButton = KeyCode.Joystick1Button0;
                bButton = KeyCode.Joystick1Button1;
                xButton = KeyCode.Joystick1Button2;
                yButton = KeyCode.Joystick1Button3;
                axis1X = "Horizontal2";
                axis1Y = "Vertical2";
                axis2X = "Horizontal2-r";
                axis2Y = "Vertical2-r";
                break;
            case 3:
                leftTrigger = "Fire3";
                rightTrigger = "Fire3-r";
                aButton = KeyCode.Joystick1Button0;
                bButton = KeyCode.Joystick1Button1;
                xButton = KeyCode.Joystick1Button2;
                yButton = KeyCode.Joystick1Button3;
                axis1X = "Horizontal3";
                axis1Y = "Vertical3";
                axis2X = "Horizontal3-r";
                axis2Y = "Vertical3-r";
                break;
            case 4:
                leftTrigger = "Fire4";
                rightTrigger = "Fire4-r";
                aButton = KeyCode.Joystick1Button0;
                bButton = KeyCode.Joystick1Button1;
                xButton = KeyCode.Joystick1Button2;
                yButton = KeyCode.Joystick1Button3;
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
}
