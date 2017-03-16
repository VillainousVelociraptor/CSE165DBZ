using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour {

    public GameObject hand;
    public OVRInput.Controller controller;

    private GameObject grabbedObject = null;
    private Transform objectOrgParent = null;
    public static bool grabEnabled;


    private void OnCollisionStay(Collision collision)
    {
        //Executes when grabbing is enabled and the left trigger was pressed
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && grabEnabled)
        {
            Debug.Log("Inside of OnCollisionStay");
            if (collision.gameObject.tag == "Bad Guy") //Can only grab bad guys
            {
                //The object that was collided with becomes the grabbed object
                grabbedObject = collision.gameObject;
                Debug.Log("Parent of grabbed object before grab: " + objectOrgParent);

                //Makes the grabbed object kinematic
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;

                objectOrgParent = grabbedObject.transform.parent;
                Debug.Log("Parent of grabbed object after grab: " + grabbedObject.name);

                //Makes the hand the parent of the grabbed object
                //grabbedObject.transform.parent = hand.transform;
                grabbedObject.transform.SetParent(hand.transform);
            }

        }
    }

    private void Update()
    {

        if (grabbedObject != null)
        {
            if (!OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
            {
                //Debug.Log(grabbedObject.name);
                grabbedObject.transform.SetParent(null);
                //grabbedObject.transform.parent = nulll;
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;

                grabbedObject = null;

            }
        }
    }


}

