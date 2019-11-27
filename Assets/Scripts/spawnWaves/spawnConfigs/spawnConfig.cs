using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnConfig : MonoBehaviour
{
    static Enemy[] enemies;
    public static GameObject[] spawnPoints;
    int[] positions;

    // Start is called before the first frame update
    void Start()
    {

        foreach (var item in positions)
        {

            spawnInPosition(spawnPoints[positions[item]], enemies[item]);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnInPosition(GameObject position, Enemy enemy)
    {

        Instantiate(enemy, position.transform);

    }
}
