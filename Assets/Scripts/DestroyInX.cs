using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInX : MonoBehaviour
{
    public float time;

    private void Start()
    {
        Destroy(this.gameObject, 5);
    }

    private void Update() 
    {
        //time -= Time.deltaTime;
        //if (time <= 0)
        //{
        //    Destroy(this.gameObject, 5);
        //}
    }
    //public void DestroyInXSec(float inputTime)
    //{
        //time = inputTime;
    //}
}
