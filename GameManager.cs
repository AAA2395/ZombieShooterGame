﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int kills = 0;
    private int currentWaveKillsGoal = 0;

    [SerializeField] ZombieSpawner zombieSpawner;
    private int currentWave = 1;
    [SerializeField] private int waveAmount = 3;
    [SerializeField] private int waveMultiplierIncrease = 2;
    [SerializeField] private int DELAY_BETWEEN_WAVES = 10;

    [SerializeField] WeaponManager weaponManager;
    private SoundFXManager soundFXManager;

    private void Awake(){
        // If there is an instance, and it's not me, delete myself
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }


    private void Start(){
        Time.timeScale = 1;
        soundFXManager = SoundFXManager.Instance;
        StartCoroutine(StartNewWave());
    }

    public void IncreaseKills(){
        kills++;
        UIManager.Instance.UpdateKills(kills);

        if(kills == weaponManager.nextUpgradeScore){
            weaponManager.UpgradeWeapon();
        }

        if(kills == currentWaveKillsGoal){
            StartCoroutine(UIManager.Instance.WaveComplete());
            soundFXManager.PlayWaveCompleteSound();
            StartCoroutine(StartNewWave());
        }
    }

    public IEnumerator StartNewWave(){
        yield return new WaitForSeconds(DELAY_BETWEEN_WAVES);
        StartCoroutine(UIManager.Instance.WaveIncoming());
        soundFXManager.PlayZombieGroanSound();
        zombieSpawner.normalZombiesToSpawn += waveAmount;
        zombieSpawner.babyZombiesToSpawn += waveAmount;
        zombieSpawner.bigZombiesToSpawn += 1;

        // set current goal for when the wave will end
        currentWaveKillsGoal = (zombieSpawner.normalZombiesToSpawn + zombieSpawner.babyZombiesToSpawn + zombieSpawner.bigZombiesToSpawn);

        waveAmount*=waveMultiplierIncrease;
        currentWave++;
    }

    public void GameOver(){
        UIManager.Instance.GameOver();

        // save score if its a high score
        int previousHighScore =  PlayerPrefs.GetInt("Highscore");
        if(kills > previousHighScore){
            // saves high score
            PlayerPrefs.SetInt("Highscore", kills);
        }
    }
}

