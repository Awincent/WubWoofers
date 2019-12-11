using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microRocket : MonoBehaviour
{
    Rigidbody rb;
    CapsuleCollider collider;
    [SerializeField] public float maxSpeed;
    float speed;
    [SerializeField] public float acceleration;
    [SerializeField] float explotionSize;
    [SerializeField] float targetingSpeed;
    [SerializeField] float explodeSpeed;
    [SerializeField] float explodeTime;
    float remainingExplodeTime;
    bool active = false;
    [SerializeField] float timeTillActive;
    float remainingTimeTillActive;
    [SerializeField] GameObject explotion;
    [SerializeField] GameObject model;
    [SerializeField] float timeTillDeath;
    float remainingTimeTillDeath;
    bool growingExplotion = true;
    bool recedingExplotion = false;
    GameObject[] enemies;
    GameObject targetEnemy;
    Vector3 direction;
    bool exploding = false;

    void Start()
    {
        remainingTimeTillActive = timeTillActive;
        speed = 1f;
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        
        if(remainingTimeTillActive > 0)
        {

            remainingTimeTillActive -= Time.deltaTime;

        }
        else
        {

            BeatManager.instance.addActionToQueue(setActive);

        }

        remainingTimeTillDeath -= Time.deltaTime;

        speed = Mathf.Lerp(speed, maxSpeed, acceleration);

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (exploding == true)
        {



        }

        if (enemies[0] != null && exploding == false && active == true)
        {
            targetEnemy = enemies[0];

            foreach (GameObject item in enemies)
            {
                if (enemies[0] != null)
                {
                    if (Vector3.Distance(transform.position, item.transform.position) < Vector3.Distance(transform.position, targetEnemy.transform.position))
                    {

                        targetEnemy = item;

                    }

                }

                print(targetEnemy);
            }


            direction = targetEnemy.transform.position - transform.position;

            transform.forward = Vector3.Lerp(transform.forward, direction, targetingSpeed);
        }
        else if(exploding == true)
        {

            rb.velocity = new Vector3(0,0,0);
            remainingExplodeTime -= Time.deltaTime;

            if (remainingExplodeTime >= explodeTime / 2)
            {


                explotion.transform.localScale = Vector3.Lerp(explotion.transform.localScale, new Vector3(explotionSize, explotionSize, explotionSize), explodeSpeed);

            }
            else if (remainingExplodeTime < explodeTime / 2)
            {

                    explotion.transform.localScale = Vector3.Lerp(explotion.transform.localScale, new Vector3(0, 0, 0), explodeSpeed);

                
            }
            if (remainingExplodeTime <= 0)
            {


                //Destroy(this.gameObject);
                addDeleteToQueue();

            }

        }

        //if (targetEnemy != null)
        //{



        //direction.Normalize();

        //}

        //Quaternion qdirection_ = transform.position  targetEnemy.transform.position;

        //Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetEnemy.transform.position), targetingSpeed);

        //Vector3.Lerp(transform.forward, direction, targetingSpeed);


        rb.velocity = transform.forward * speed;

    }


    public void Explode()
    {

        model.SetActive(false);
        explotion.SetActive(true);
        rb.isKinematic = true;
        exploding = true;

    }
    public void setActive()
    {

        active = true;

    }
    public void addDeleteToQueue()
    {

        Destroy(this.gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            collider.enabled = false;
            print("OOga");
            BeatManager.instance.addActionToQueue(Explode);
        }
    }
}
