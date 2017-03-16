using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandFlying : MonoBehaviour {

    public GameObject hand;
    public OVRInput.Controller controller;
    public static bool flyEnabled; //is flying enabled 
    public float speed = 3.0f; //flying speed
    public GameObject cloud;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.GetDown(OVRInput.Button.Two)){
            //Pressing the Y button makes flying false
            flyEnabled = false; //Pressing the Y button makes flying false
        }
        else if (OVRInput.GetDown(OVRInput.Button.One))
        {
            //Pressing the X button makes flying true
            flyEnabled = true;
        }

        if (flyEnabled)
        {
            //The character flyes in the direction of the left hand
            transform.position += hand.transform.forward * Time.deltaTime * speed;
            cloud.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            cloud.GetComponent<Renderer>().enabled = false;
        }


	}
}
