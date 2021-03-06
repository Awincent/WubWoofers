﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public spawnConfig[] configs;
    //public spawnWave[] waves;
    public GameObject[] spawnPoints;
    int curentSpawner;
    public Enemy enemyPrefab;
    

    public float targetTime = 2;
    float staticTime;


    // Start is called before the first frame update
    void Start()
    {

        //configs[1].doSpawns();

        staticTime = targetTime;
    }

    // Update is called once per frame
    void Update()
    {
        curentSpawner = Random.Range(0, spawnPoints.Length);


        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {

            targetTime = staticTime;
            BeatManager.instance.addActionToQueue(SpawnEnemy);
        }




    }

    public void SpawnEnemy()
    {
        curentSpawner = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[curentSpawner].transform);

    }

}
