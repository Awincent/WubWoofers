using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hubert : MonoBehaviour
{
    public float hubertSpeed;
    GameObject hubert;
    Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        
        vector = new Vector3(hubertSpeed,0,hubertSpeed);
        hubert = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        hubert.transform.position += vector;
    }
}
