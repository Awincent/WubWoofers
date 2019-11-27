//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class spawnConfig : MonoBehaviour
//{
//    public static Enemy[] enemies;
//    public Enemy[] enemiesToSpawn;
//    public static GameObject[] spawnPoints;
//    protected int[] positions;
    

//    // Start is called before the first frame update
//    void Start()
//    {
//        enemies = GetComponentInParent<Spawner>().enemyPrefabs;


//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    public void doSpawns()
//    {

//        foreach (var item in positions)
//        {

//            spawnInPosition(spawnPoints[positions[item]], enemiesToSpawn[item]);

//        }

//    }

//    public void spawnInPosition(GameObject position, Enemy enemy)
//    {

//        Instantiate(enemy, position.transform);

//    }
//}
