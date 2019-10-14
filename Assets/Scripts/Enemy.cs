using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    
    public float speed = 5;
    public GameObject[] parts;
    public GameObject eye;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {  
        rb.velocity = Vector3.forward * speed * Time.deltaTime;

    }

    public ParticleSystem deathParticle;
    void EnemyDeath()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        for (int i = 0; i < parts.Length; i++)
        {
            GameObject gameObject = parts[i].GetComponent<GameObject>();
            Destroy(gameObject);

        }
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider other) 
    {
        Debug.Log("collided");
        if(other.gameObject.tag == "Bullet")
        {
            StartCoroutine(Hit());
        }
    }

    public float slowDownTime = 2;
    public float slowDownSpeed = 0.9f;

    public IEnumerator Hit()
    {
        
        float timeHit = Time.time; //Stores the current time
        while(Time.time - timeHit < slowDownTime) //wait until (slowDownTime) seconds have passed
        {
            //Debug.Log(speed);
            speed *= slowDownSpeed; //gradually decreases speed
            yield return new WaitForEndOfFrame();
        }

        EnemyDeath();
    }
     private void OnMouseUp()
        {
            StartCoroutine(Hit());
        }
}
