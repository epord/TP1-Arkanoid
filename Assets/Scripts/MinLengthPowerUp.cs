using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinLengthPowerUp : MonoBehaviour, PowerUp
{

    private GameObject player;
    private bool active;
    public float timer = 10;
    private SoundManager soundManager;
    private PowerUpManager powerUpManager;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
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
        player.GetComponent<mover>().unSetLongMode();
        this.transform.position = new Vector2(-10000, 0);
        var falling = GetComponent<FallingPowerUp>();
        Destroy(falling);
        active = true;
        soundManager.PlayPowerUp();
    }

    public void UnsetPowerUp()
    {
        player.GetComponent<mover>().setLongMode();
        Destroy(gameObject);
    }
}
