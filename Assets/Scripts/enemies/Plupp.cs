using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plupp : Enemy
{
    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = Vector3.forward * speed * Time.deltaTime;


    }
}
