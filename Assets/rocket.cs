using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{

    Rigidbody rb;
    CapsuleCollider collider;
    [SerializeField] public float speed;
    [SerializeField] float explotionSize;
    [SerializeField] float deviation;
    [SerializeField] float deviationSpeed;
    [SerializeField] float explodeSpeed;
    bool active = false;
    private Vector3 currentDeviation_;
    [SerializeField] GameObject explotion;
    [SerializeField] GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        BeatManager.instance.addActionToQueue(startThrust);
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {


        if (active)
        {

            currentDeviation_ = Vector3.Lerp(transform.forward, transform.forward + new Vector3(Random.Range(-deviation, deviation), Random.Range(-deviation, deviation), Random.Range(-deviation, deviation)), deviationSpeed);

            rb.AddForce(speed * transform.forward);//transform.rotation = Quaternion.LookRotation(new Vector3(Random.Range(0, deviation), Random.Range(0, deviation), Random.Range(0, deviation)));
            transform.rotation = Quaternion.LookRotation(currentDeviation_);
        }

    }

    public void startThrust()
    {

        active = true;

    }
    
    private void OnTriggerEnter(Collider other)
    {

        BeatManager.instance.addActionToQueue(Explode);

    }
    private void Explode()
    {
        speed = 0;
        deviation = 0;
        rb.isKinematic = true;
        model.SetActive(false);
        explotion.SetActive(true);
        explotion.transform.localScale = Vector3.Lerp(explotion.transform.localScale, new Vector3(explotionSize, explotionSize, explotionSize), explodeSpeed);

    }

}
