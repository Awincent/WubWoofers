using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketLauncher : Weapon
{
    
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

        audioSource.Play();


        Instantiate(bullet, whereShoot.transform.position, whereShoot.transform.rotation);

    }


}
