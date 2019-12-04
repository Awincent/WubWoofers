using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSlinger : MonoBehaviour
{

    public GameObject rocket;
    public Transform shootFrom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GameObject.Instantiate(rocket, shootFrom);
        }
        
    }
}
