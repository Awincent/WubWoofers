using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject whereShoot;
    public float grabDistance;
    public GameObject leftController;
    public GameObject leftModel;
    public GameObject rightController;
    public GameObject rightModel;
    public SteamVR_Action_Boolean shoot;
    public SteamVR_Action_Boolean grab;
    public SteamVR_Input_Sources leftControllerSource;
    public SteamVR_Input_Sources rightControllerSource;
    public bool grabbed = false;
    Rigidbody rb;
    Vector3 currentControllerPos;
    Vector3 lastControllerPos;
    GameObject grabbingController;
    public float pickupTimer;
    private float currentPickupTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grab.AddOnStateDownListener(SqueezeOut, leftControllerSource);
        grab.AddOnStateUpListener(SqueezeIn, leftControllerSource);
        grab.AddOnStateDownListener(SqueezeOut, rightControllerSource);
        grab.AddOnStateUpListener(SqueezeIn, rightControllerSource);
        shoot.AddOnStateDownListener(TriggerDown, leftControllerSource);
        shoot.AddOnStateUpListener(TriggerUp, leftControllerSource);
        shoot.AddOnStateDownListener(TriggerDown, rightControllerSource);
        shoot.AddOnStateUpListener(TriggerUp, rightControllerSource);
        grabbingController = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentPickupTimer > 0)
        {

            currentPickupTimer = currentPickupTimer - Time.deltaTime;

        }

    }

    public void SqueezeIn(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        print("Trigger is up!");


    }
    public void SqueezeOut(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        bool rightHand = false;

        print("Trigger is down!");

        if (fromSource == rightControllerSource)
        {

            rightHand = true;

        }
        else if (fromSource == leftControllerSource)
        {

            rightHand = false;

        }

        if (Vector3.Distance(transform.position, leftController.transform.position) < grabDistance && rightHand == false && currentPickupTimer <= 0 || Vector3.Distance(transform.position, rightController.transform.position) < grabDistance && rightHand == true && currentPickupTimer <=0)
        {

            GameObject actingController;
            GameObject actingModel;

            if (rightHand == true)
            {

                actingController = rightController;
                actingModel = rightModel;
            }
            else
            {

                actingController = leftController;
                actingModel = leftModel;
            }


            if (grabbed == true && grabbingController == actingController)
            {

                
                rb.isKinematic = false;
                rb.velocity = actingController.GetComponent<Rigidbody>().velocity;
                transform.parent = null;
                grabbed = false;
                actingModel.SetActive(true);

            }
            else if (grabbed == false)

            {
                currentPickupTimer = pickupTimer;
                grabbingController = actingController;
                rb.isKinematic = true;
                actingModel.SetActive(false);
                transform.parent = actingController.transform;
                transform.position = actingController.transform.position;
                transform.rotation = actingController.transform.rotation;
                grabbed = true;
            }

        }



    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        print("Up");

    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        bool rightHand = false;


        if (fromSource == rightControllerSource)
        {

            rightHand = true;

        }
        else if (fromSource == leftControllerSource)
        {

            rightHand = false;

        }

        if(rightHand == true && grabbingController == rightController || rightHand == false && grabbingController == leftController)
        {

            BeatManager.instance.addActionToQueue(Shoot);

        }

        
    }
    public virtual void Shoot()
    {

        
        Instantiate(bullet, whereShoot.transform.position, whereShoot.transform.rotation);


    }


}
