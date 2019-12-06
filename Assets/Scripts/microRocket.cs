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
    [SerializeField] GameObject explotion;
    [SerializeField] GameObject model;
    [SerializeField] float timeTillDeath;
    float remainingTimeTillDeath;
    bool growingExplotion = true;
    bool recedingExplotion = false;
    GameObject[] enemies;
    GameObject targetEnemy;
    Vector3 direction;

    void Start()
    {

        speed = 1f;
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {

        speed = Mathf.Lerp(speed, maxSpeed, acceleration);

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        

        if (enemies[0] != null)
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
        }

        //if (targetEnemy != null)
        //{



        //direction.Normalize();

        //}

        //Quaternion qdirection_ = transform.position  targetEnemy.transform.position;

        //Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targetEnemy.transform.position), targetingSpeed);

        //Vector3.Lerp(transform.forward, direction, targetingSpeed);

        direction = targetEnemy.transform.position - transform.position;

        transform.forward = Vector3.Lerp(transform.forward, direction, targetingSpeed);

        rb.velocity = transform.forward * speed;

    }
}
