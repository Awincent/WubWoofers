﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject chosenGun;

    public GameObject whereShoot;

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(bullet, whereShoot.transform);
        }
    }

}
