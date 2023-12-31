﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{   
    public GameObject normalZombie;
    public GameObject bigZombie;
    public GameObject babyZombie;

    public int normalZombiesToSpawn = 0;

    public int normalZombiesSpawnedCount = 0;
    
    public int bigZombiesToSpawn = 0;

    public int bigZombiesSpawnedCount = 0;

    public int babyZombiesToSpawn = 0;

    public int babyZombiesSpawnedCount = 0;

    void Update()
    {   
        if((normalZombiesSpawnedCount >= normalZombiesToSpawn) && (bigZombiesSpawnedCount >= bigZombiesToSpawn) && (babyZombiesSpawnedCount >= babyZombiesToSpawn)){
            return;
        }

        if(Random.Range(0.0f, 100.0f) < 1){
            float xPos = 20.0f;
            float zPos = 20.0f;
            
            if(Random.Range(0.0f, 100.0f) > 50){
                if(Random.Range(0.0f, 100.0f) > 50){
                    xPos = -20.0f;
                }
                zPos = Random.Range(-20.0f, 20.0f);
            }else{
                if(Random.Range(0.0f, 100.0f) > 50){
                    zPos = -20.0f;
                }
                xPos = Random.Range(-20.0f, 20.0f);
            }

            Vector3 spawnPoint = new Vector3(xPos, 0, zPos);
            
            if(babyZombiesSpawnedCount < babyZombiesToSpawn){
                Instantiate(babyZombie, spawnPoint, Quaternion.identity);
                babyZombiesSpawnedCount++;
            }else if(normalZombiesSpawnedCount < normalZombiesToSpawn){
                Instantiate(normalZombie, spawnPoint, Quaternion.identity);
                normalZombiesSpawnedCount++;
            }else if(bigZombiesSpawnedCount < bigZombiesToSpawn){
                Instantiate(bigZombie, spawnPoint, Quaternion.identity);
                bigZombiesSpawnedCount++;
            }
        }
    }
}
