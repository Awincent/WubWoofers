using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    GameObject enemy;
    public float speed = 5;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        enemy = this.gameObject;
        movement = Vector3.forward * 5f * Time.deltaTime;

    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("work?");
        enemy.transform.Translate(movement);
    }
}
