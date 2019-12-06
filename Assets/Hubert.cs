using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hubert : MonoBehaviour
{
    GameObject hubert;
    Vector3 vector = new Vector3(.05f,0,.05f);

    // Start is called before the first frame update
    void Start()
    {
        hubert = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        hubert.transform.position += vector;
    }
}
