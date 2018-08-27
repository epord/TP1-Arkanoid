﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinLengthPowerUp : MonoBehaviour, PowerUp
{

    private GameObject player;
    private bool active;
    public float timer = 10;
    private SoundManager soundManager;
    private PowerUpManager powerUpManager;
    private ScoreManager scoreManager;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.updateScore(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timer = Mathf.Max(timer - Time.deltaTime, 0);
            if (timer == 0)
            {
                powerUpManager.ReleasePowerUp();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.name == "player")
        {
            SetPowerUp();
        }
    }

    public void SetPowerUp()
    {
        powerUpManager.SetPowerUp(this);
        player.GetComponent<mover>().SetShortMode();
        var falling = GetComponent<FallingPowerUp>();
        Destroy(falling);
        active = true;
        this.transform.position = new Vector2(-10000, 0);
        soundManager.PlayPowerUp();
    }

    public void UnsetPowerUp()
    {
        player.GetComponent<mover>().UnsetShortMode();
        Destroy(gameObject);
    }
}
