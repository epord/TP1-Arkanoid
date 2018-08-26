using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPowerUp : MonoBehaviour, PowerUp {
    private Vector2 temp;
    public float timer = 10;
    private bool active;
    private GameObject[] balls;
    private SoundManager soundManager;
    private PowerUpManager powerUpManager;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
    }

    public void Update()
    {
        if (active) {
            timer = Mathf.Max(timer - Time.deltaTime, 0);
            if (timer == 0)
            {
                powerUpManager.ReleasePowerUp();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.name == "player")
        {
            SetPowerUp();
        }
    }

    public void SetPowerUp()
    {
        powerUpManager.SetPowerUp(this);
        balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var ball in balls)
        {
            ball.GetComponent<Ball_move>().SetStickMode();
        }
        this.transform.position = new Vector2(-10000, 0);
        var falling = GetComponent<FallingPowerUp>();
        Destroy(falling);
        active = true;
        soundManager.PlayPowerUp();
    }

    public void UnsetPowerUp()
    {
        if (active)
        {
            foreach (var ball in balls)
            {
                if (ball != null)
                {
                    var ballMove = ball.GetComponent<Ball_move>();
                    ballMove.NoStickMode();
                }
            }
        }
        Destroy(this);
    }
}
