using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class pitto : Weapon
{
    bool holding = false;
    protected AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

        base.Start();

        audioSource = gameObject.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

        base.Update();

        if (holding == true)
        {

            bool alreadyAdded = BeatManager.instance.allHalfbeatActions.Contains(Shoot);


            if (alreadyAdded == false)
            {

                print("Woop?");
                BeatManager.instance.addActionToHalfbeatQueue(Shoot);

            }


        }

    }
    public override void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
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

        if (rightHand == true && grabbingController == rightController || rightHand == false && grabbingController == leftController)
        {


            holding = false;


        }

    }

    public override void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
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

        if (rightHand == true && grabbingController == rightController || rightHand == false && grabbingController == leftController)
        {


            holding = true;


        }


    }

    public override void addShootToQueue()
    {



    }
    public override void Shoot()
    {

        audioSource.Play();

        Instantiate(bullet, whereShoot.transform.position, whereShoot.transform.rotation);


    }

}
