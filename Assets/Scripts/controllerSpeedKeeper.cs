using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerSpeedKeeper : MonoBehaviour
{

    public Vector3 controllerVelocity;
    private Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controllerVelocity = transform.position - lastPos;

        print(controllerVelocity);


        lastPos = transform.position;
    }


}
