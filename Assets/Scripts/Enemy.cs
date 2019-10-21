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
    public void EnemyDeath()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        for (int i = 0; i < parts.Length; i++)
        {
            GameObject gameObject = parts[i].GetComponent<GameObject>();
            Destroy(gameObject);

        }
        Destroy(this.gameObject);
        print("Object Destroyed");
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

        speed *= slowDownSpeed;
        BeatManager.instance.addActionToQueue(EnemyDeath);
        yield break;

    }
     private void OnMouseUp()
        {
        
            StartCoroutine(Hit());
        }
}
