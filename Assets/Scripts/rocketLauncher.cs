using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketLauncher : Weapon
{
    bool reloading = false;

    private void Start()
    {
        base.Start();
        audioSource = gameObject.GetComponent<AudioSource>();


    }
    private void Update()
    {

        base.Update();

    }
    public override void Shoot()
    {
        if (reloading == false)
        {


            audioSource.Play();
            Instantiate(bullet, whereShoot.transform.position, whereShoot.transform.rotation);
            BeatManager.instance.addActionToQueue(feedAmmo);
            reloading = true;

        }
        else
        {

            return;

        }

    }
    public void feedAmmo()
    {

        BeatManager.instance.addActionToQueue(load);

    }
    public void load()
    {

        BeatManager.instance.addActionToQueue(reloadDone);

    }
    public void reloadDone()
    {

        reloading = false;

    }


}
