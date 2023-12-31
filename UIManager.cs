﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI kills;
    [SerializeField] private TextMeshProUGUI walls;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject controls;
    [SerializeField] private Image healthBar;
    [SerializeField] private List<Sprite> healthStages;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI experience;

    [SerializeField] private GameObject waveComplete;

    [SerializeField] private GameObject waveIncoming;

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateHealth(int health_int)
    {
        health.SetText(string.Format("{0}", health_int));
        if (health_int <= 100 && health_int > 75) {
                healthBar.sprite = healthStages[0];
                health.color = Color.white;
        }

        if (health_int <= 75 && health_int > 50) {
                healthBar.sprite = healthStages[1];
                health.color = Color.black;
        }

        if (health_int <= 50 && health_int > 25) {
                healthBar.sprite = healthStages[2];
                health.color = Color.white;
        }

        if (health_int <= 25 && health_int > 0) {
                healthBar.sprite = healthStages[3];
                health.color = Color.white;
        }

        if (health_int == 0) {
                healthBar.sprite = healthStages[4];
                health.color = Color.white;
        }
    }

    public void UpdateKills(int kills_int)
    {
        kills.SetText(string.Format("{0}", kills_int));
    }

    public void UpdateWallCount(int walls_int)
    {
        walls.SetText(string.Format("{0}", walls_int));
    }

    public void UpdateLevel(int level_int)
    {
        level.SetText(string.Format("Level: {0}", level_int));
    }

    public void UpdateExperience(int experience_int)
    {
        experience.SetText(string.Format("Experience: {0}", experience_int));
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        controls.gameObject.SetActive(false);
    }

    public IEnumerator WaveComplete()
    {
        waveComplete.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        waveComplete.gameObject.SetActive(false);
    }

    public IEnumerator WaveIncoming()
    {
        waveIncoming.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        waveIncoming.gameObject.SetActive(false);
    }
}
