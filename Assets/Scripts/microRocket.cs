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
    [SerializeField] public float decceleration;
    [SerializeField] float explotionSize;
    [SerializeField] float targetingSpeed;
    [SerializeField] float explodeSpeed;
    [SerializeField] float explodeTime;
    float remainingExplodeTime;
    bool active = false;
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
        speed = 10f;
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        remainingTimeTillDeath = timeTillDeath;

    }

    void Update()
    {

        rb.velocity = transform.forward * speed;

        if (active == false || targetEnemy == null)
        {

            speed = Mathf.Lerp(speed, 0, decceleration);
            if(active == false)
            {


                BeatManager.instance.addActionToQueue(setActive);

            };
        }
        else
        {

            speed = Mathf.SmoothStep(speed, maxSpeed, acceleration);

        }

        

        remainingTimeTillDeath -= Time.deltaTime;
        
        if(remainingTimeTillDeath < 0)
        {
            BeatManager.instance.addActionToQueue(Explode);
            

        }

        ////speed = Mathf.Lerp(speed, maxSpeed, acceleration);
        

        print(active);

        enemies = GameObject.FindGameObjectsWithTag("Enemy");


        if (enemies[0] != null && exploding == false && active == true)
        {
            targetEnemy = enemies[0];

            targetEnemy = enemies[Random.Range(0, enemies.Length)];


            direction = targetEnemy.transform.position - transform.position;

            transform.forward = Vector3.MoveTowards(transform.forward, direction, targetingSpeed);
        }
        else if(exploding == true)
        {
            
            rb.velocity = new Vector3(0,0,0);
            remainingExplodeTime -= Time.deltaTime;
            explotion.SetActive(true);

            if (remainingExplodeTime > explodeTime / 2)
            {


                explotion.transform.localScale = Vector3.Lerp(explotion.transform.localScale, new Vector3(explotionSize, explotionSize, explotionSize), explodeSpeed);

            }
            else if (remainingExplodeTime < explodeTime / 2 && remainingExplodeTime > 0)
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

        print(targetEnemy);


    }


    public void Explode()
    {
        remainingExplodeTime = explodeTime;
        model.SetActive(false);
        explotion.SetActive(true);
        exploding = true;

    }
    public void setActive()
    {



        active = true;
        print("Set to active");
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
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        }
    }
}
