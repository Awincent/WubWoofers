using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroRocketLauncher : Weapon
{
    bool reloading = false;
    public delegate void Action();
    float lateTimerMax = 0.1f;
    float lateTimerCurrent = 0.1f;
    public GameObject[] shootPoints;
    public enum ReloadState { ready, feeding, loading, finishing }
    private ReloadState reloadState;
    private int whatReloadState;


    private void Start()
    {
        base.Start();
        audioSource = gameObject.GetComponent<AudioSource>();


    }
    private void Update()
    {

        base.Update();

        switch (reloadState)
        {
            case ReloadState.ready:

                if (whatReloadState == 1)
                {


                    reloadState = ReloadState.feeding;
                    BeatManager.instance.addActionToQueue(feedAmmo);

                }

                break;
            case ReloadState.feeding:

                if (whatReloadState == 2)
                {

                    reloadState = ReloadState.loading;
                    BeatManager.instance.addActionToQueue(load);

                }

                break;
            case ReloadState.loading:
                print("3");
                if (whatReloadState == 3)
                {

                    reloadState = ReloadState.finishing;
                    BeatManager.instance.addActionToQueue(reloadDone);

                }

                break;
            case ReloadState.finishing:
                print("4");
                reloadState = ReloadState.ready;
                whatReloadState = 0;

                break;
        }

    }

    public override void Shoot()
    {
        if (reloadState == ReloadState.ready)
        {

            whatReloadState = 1;
            audioSource.Play();

            foreach (GameObject item in shootPoints)
            {

                Instantiate(bullet, item.transform.position, item.transform.rotation);

            }



        }
        else
        {

            return;

        }

    }
    public void feedAmmo()
    {
        whatReloadState++;

    }
    public void load()
    {
        whatReloadState++;

    }
    public void reloadDone()
    {
        reloading = false;

    }


}
