using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameObject bullet;
    public Rigidbody rigidbody;
    public float speed;
    public float lerpSpeed;
    public float strechFactor;
    public float strechSpeed;
    public float timeTillSlowdown;
    private float remainingTimeTillSlowdown;
    private bool stopping = false;
    public float slowDownFactor;
    public float gravity;
    public GameObject sphere;

    void Start()
    {

        remainingTimeTillSlowdown = timeTillSlowdown;
        bullet = this.gameObject;
    }


    void Update()
    {
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, transform.forward * speed * Time.deltaTime, lerpSpeed);
        sphere.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.2f, 0.2f, strechFactor * rigidbody.velocity.z * 0.2f), strechSpeed);

        if (remainingTimeTillSlowdown > 0) { remainingTimeTillSlowdown -= Time.deltaTime; }
        else
        {

            speed = Mathf.Lerp(speed, 0, slowDownFactor);
            
        };

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
