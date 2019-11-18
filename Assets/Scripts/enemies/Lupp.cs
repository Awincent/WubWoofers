using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lupp : Enemy
{
    private Collider headCollider;
    public GameObject head;
    public GameObject partPrefab;
    int segments;
    public int maxSegments;
    public int minSegments;
    private bool initiating = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        headCollider = head.GetComponent<Collider>();

        segments = Random.Range(minSegments, maxSegments);


    }

    // Update is called once per frame
    void Update()
    {


        if (initiating == true)
        {


            for (int i = 0; i < segments; i++)
            {

                parts.Add(Instantiate(partPrefab.GetComponent<enemyPart>(), transform));
            }

            initiating = false;
        }
        GetComponentInChildren<luppHead>().headrb.velocity = Vector3.forward * speed * Time.deltaTime;

        //Vector3 targetPosition = head.transform.position - parts[0].transform.position;

        if (parts.Count > 0 && parts[0] != null)
        {


            parts[0].transform.position = Vector3.Lerp(parts[0].transform.position, offsetTarget(head.transform.position)/* - targetPosition.normalized*/, 0.05f);



            for (int i = 1; i < parts.Count; i++)
            {
                if (parts[i - 1] == null)
                {

                    BeatManager.instance.addActionToQueue(parts[i].DestroyPart);
                    //parts.RemoveAt(i);

                }

                print(parts[i]);

                //if (parts[i - 1] != null && parts[i] != null)
                //{
                /*Vector3 targetPosition = parts[i - 1].transform.position - offsetTarget(parts[i].transform.position)*//* - transform.position;*/
                parts[i].transform.position = Vector3.Lerp(parts[i].transform.position, offsetTarget(parts[i - 1].transform.position)/* - targetPosition.normalized*/, 0.05f);
                //}


            }

        }
        else if (parts[0] = null)
        {

            foreach (var item in parts)
            {

                BeatManager.instance.addActionToQueue(item.DestroyPart);

            }

        }




        //rb.velocity = Vector3.forward * speed * Time.deltaTime;



    }


    public Vector3 offsetTarget(Vector3 target)
    {

        target.z = target.z - 0.5f;

        return target;
    }

    public override void OnTriggerEnter(Collider other)
    {


    }

}
