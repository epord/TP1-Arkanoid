using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePowerUp : MonoBehaviour, PowerUp
{

    public float timer = 10;
    private bool active;
	private GameObject player;
    public GameObject projectile1;
    private SoundManager soundManager;
    private PowerUpManager powerUpManager;


	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
	    powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			timer = Mathf.Max(timer - Time.deltaTime, 0);
            if (timer == 0)
            {
				powerUpManager.ReleasePowerUp();
			}
			
        	if (Input.GetKeyDown(KeyCode.Space))
			{
				float playerX = player.transform.position.x;
				float playerY = player.transform.position.y + 5;

				var bullet = Instantiate(projectile1);
				bullet.transform.position = new Vector2(playerX, playerY);
				bullet.transform.rotation = transform.rotation;
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
        active = true;
        this.transform.position = new Vector2(-10000, 0);
        var falling = GetComponent<FallingPowerUp>();
        Destroy(falling);
        soundManager.PlayPowerUp();
    }

    public void UnsetPowerUp()
    {
        Destroy(gameObject);
    }
}
