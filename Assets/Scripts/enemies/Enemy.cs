using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float slowDownSpeed;
    public float slowDownTime;
    protected float health;
    public List<enemyPart> parts;
    protected Rigidbody rb;
    public ParticleSystem deathParticle;
    public AudioClip enemyDeathSound;
    private AudioSource audioSource;

    private void Start()
    {

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = enemyDeathSound;

        if(parts.Count >= 1)
        {

            health = parts.Count;

        }
        else
        {

            health = 1;
        }
        


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


        if(parts.Count > 1)
        {
            health--;

            BeatManager.instance.addActionToQueue(parts[parts.Count - 1].DestroyPart);
            parts.RemoveAt(parts.Count - 1);
        }
        else
        {


            speed = Mathf.Lerp(speed, speed * slowDownSpeed, slowDownTime);
            BeatManager.instance.addActionToQueue(EnemyDeath);

        }
        yield break;

    }
    public void EnemyDeath()
    {
        audioSource.Play();

        if(deathParticle != null)
        {

            Instantiate(deathParticle, transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
        print("Object Destroyed");

    }
    void partDeath(enemyPart part)
    {


        BeatManager.instance.addActionToQueue(part.DestroyPart);

    }
    private void OnMouseUp()
    {

        StartCoroutine(Hit());

    }
}
