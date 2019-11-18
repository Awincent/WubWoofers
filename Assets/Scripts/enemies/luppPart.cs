using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luppPart : enemyPart
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            BeatManager.instance.addActionToQueue(DestroyPart);
        }


    }
    private void OnMouseUp()
    {

        
        BeatManager.instance.addActionToQueue(DestroyPart);


    }
}
