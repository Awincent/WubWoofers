using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketLauncher : Weapon
{
    bool reloading = false;
    public delegate void Action();
    float lateTimerMax = 0.1f;
    float lateTimerCurrent = 0.1f;
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
                    print("Feed part1");
                }

                break;
            case ReloadState.feeding:

                if (whatReloadState == 2)
                {

                    reloadState = ReloadState.loading;
                    BeatManager.instance.addActionToQueue(load);
                    print("Load Part1");
                }

                break;
            case ReloadState.loading:

                if (whatReloadState == 3)
                {

                    reloadState = ReloadState.finishing;
                    BeatManager.instance.addActionToQueue(reloadDone);

                }

                break;
            case ReloadState.finishing:

                if (whatReloadState == 4)
                {

                    reloadState = ReloadState.ready;
                    whatReloadState = 0;

                }


                break;
        }

    }

    public override void Shoot()
    {
        if (reloadState == ReloadState.ready && whatReloadState == 0)
        {

            whatReloadState = 1;
            audioSource.Play();
            Instantiate(bullet, whereShoot.transform.position, whereShoot.transform.rotation);

        }
        else
        {

            return;

        }

    }
    public void feedAmmo()
    {
        print("Feed Part2");
        whatReloadState++;

    }
    public void load()
    {
        whatReloadState++;
        print("Load part 2");
    }
    public void reloadDone()
    {

        whatReloadState++;

    }


}
