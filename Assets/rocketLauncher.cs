using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketLauncher : Weapon
{

    private void Start()
    {
        base.Start();


    }
    private void Update()
    {

        base.Update();

    }
    public override void Shoot()
    {

        Instantiate(bullet, whereShoot.transform);

    }


}
