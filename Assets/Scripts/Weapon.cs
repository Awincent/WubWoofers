using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float grabDistance;
    public GameObject leftController;
    public GameObject leftModel;
    public GameObject rightController;
    public SteamVR_Action_Boolean grab;
    public SteamVR_Input_Sources leftControllerSource;
    public bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {

        grab.AddOnStateDownListener(TriggerDown, leftControllerSource);
        grab.AddOnStateUpListener(TriggerUp, leftControllerSource);
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector3.Distance(transform.position, leftController.transform.position) < grabDistance || Vector3.Distance(transform.position, rightController.transform.position) < grabDistance)
        {

            print("Close enough");

            if (grab != null)
            {



            }
        }

    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        print("Trigger is up!");


    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        print("Trigger is down!");

        if (grabbed == true)
        {

            transform.parent = null;
            grabbed = false;
        }

        if (grabbed == false)
        {
            leftModel.SetActive(false);
            transform.parent = leftController.transform;
            transform.position = leftController.transform.position;
            transform.rotation = leftController.transform.rotation;
            grabbed = true;
        }




    }

}
