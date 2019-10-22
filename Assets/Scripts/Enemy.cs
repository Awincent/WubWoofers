using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float slowDownSpeed;
    public float health;
    public List<enemyPart> parts;
    public Rigidbody rb;
    

    private void Start()
    {

        rb = GetComponent<Rigidbody>();

    }
    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if (other.gameObject.tag == "Bullet")
        {
            StartCoroutine(Hit());
        }

    }
    public IEnumerator Hit()
    {

        speed *= slowDownSpeed;

        if(health > 0)
        {
            health--;
            partDeath(parts[parts.Count -1]);

        }
        else
        {


            BeatManager.instance.addActionToQueue(EnemyDeath);

        }
        yield break;

    }
    public ParticleSystem deathParticle;
    public void EnemyDeath()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        print("Object Destroyed");

    }
    void partDeath(enemyPart part)
    {

        
        Destroy(part);

    }
}
