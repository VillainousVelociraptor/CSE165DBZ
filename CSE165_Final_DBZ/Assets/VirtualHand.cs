using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar;
using System;
using Unity; 

public class VirtualHand : MonoBehaviour
{

    public GameObject hand;
    public OVRInput.Controller controller;

    public static bool menuEnabled;
    public GameObject menu;



    private void Start()
    {
        //menu.GetComponent<Renderer>().enabled = false;
        menu.SetActive(false);
        Debug.Log("Inside of VirtualHand Start method");
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.tag == "GrabButton")
        {
            Debug.Log("Triggered the grab button");
            GrabScript.grabEnabled = true;
            //FireballScript.fireEnabled = false;
        }
        else if (collision.gameObject.tag == "FireballButton")
        {
            Debug.Log("Triggered the fireball button");
            //FireballScript.fireEnabled = true;
            //GrabScript.grabEnabled = false;
        }
        else if (collision.gameObject.tag == "FlyButton")
        {
            Debug.Log("Triggered the fly button");
            if (!LeftHandFlying.flyEnabled)
            {
                //Turns on flying if it was off
                LeftHandFlying.flyEnabled = true;
            }
            else
            {
                //Turns off flying if it was on
                LeftHandFlying.flyEnabled = false;
            }          
        }
        else if(collision.gameObject.tag == "RadarButton")
        {
            Debug.Log("Triggered the radar button");
            //RadarScript.radarEnabled = true;
        }
    }

    private void Update()
    {
        //If X button is toggled...
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("X button was pressed");
            if (!menuEnabled)
            {
                //Displays menu if it was previously invisible 
                menu.SetActive(true);
                menuEnabled = true;
                //menu.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                //Hides menu if it was previously visible 
                menu.SetActive(false);
                menuEnabled = false;
                //menu.GetComponent<Renderer>().enabled = false;
            }
        }
    }


}
