using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float grabDistance;
    public GameObject leftController;
    public GameObject rightController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(transform.position, leftController.transform.position) < grabDistance || Vector3.Distance(transform.position, rightController.transform.position) < grabDistance)
        {

            GetComponent<Renderer>().material.color = Color.red;

        }

    }
    

}
