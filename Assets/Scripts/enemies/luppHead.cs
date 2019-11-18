using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luppHead : enemyPart
{
    public Rigidbody headrb;
    List<enemyPart> parts;
    // Start is called before the first frame update
    void Start()
    {
        headrb = GetComponent<Rigidbody>();
        parts = transform.parent.GetComponent<Enemy>().parts;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            BeatManager.instance.addActionToQueue(parts[parts.Count].DestroyPart);
        }
    }
    private void OnMouseUp()
    {

        if (parts.Count > 0)
        {
            BeatManager.instance.addActionToQueue(parts[parts.Count -1].DestroyPart);
            parts.RemoveAt(parts.Count -1);

        }
        else
        {

            BeatManager.instance.addActionToQueue(DestroyPart);
            BeatManager.instance.addActionToQueue(GetComponentInParent<Enemy>().EnemyDeath);
            

        }
    }
}
