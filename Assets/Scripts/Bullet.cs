using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameObject bullet;
    public Rigidbody rigidbody;
    public float speed;

    void Start()
    {
        bullet = this.gameObject;
    }


    void Update()
    {
        rigidbody.velocity = transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }   
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        } 
    }
}
