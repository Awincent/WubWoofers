using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInX : MonoBehaviour
{
    public float time;

    private void Update() 
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void DestroyInXSec(float inputTime)
    {
        time = inputTime;
    }
}
