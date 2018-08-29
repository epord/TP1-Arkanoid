using UnityEngine;

public class ProjectilePowerUp : MonoBehaviour, PowerUp
{
    public float Interval = 10;
    private float timer;
    private bool active;
	private GameObject player;
    public GameObject projectile1;
    public int MaxProjectiles = 4;
    private SoundManager soundManager;
    private PowerUpManager powerUpManager;
    private ScoreManager scoreManager;
    private GameObject[] projectilePool;

	void Start ()
    {
		player = GameObject.Find("player");
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
	    powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.updateScore(gameObject);
        projectilePool = new GameObject[MaxProjectiles];

	    for (int i = 0; i < projectilePool.Length; i++)
	    {
	        projectilePool[i] = Instantiate(projectile1);
            projectilePool[i].SetActive(false);
	        projectilePool[i].GetComponent<projectile>().SetProjectilePowerUp(this);
	    }
    }

    public void DestroyBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        for (int i = 0; i < projectilePool.Length; i++)
        {
            if (projectilePool[i] == null)
            {
                projectilePool[i] = bullet;
                break;
            }
        }
    }

    private void CreateBullet(Vector2 position)
    {
        GameObject bullet = null;
        for (int i = 0; i < projectilePool.Length; i++)
        {
            if (projectilePool[i] != null)
            {
                bullet = projectilePool[i];
                projectilePool[i] = null;
                break;
            }
        }

        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<projectile>().ResetVelocity();
        }
       
    }
	
	void Update ()
    {
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
                
                CreateBullet(new Vector2(playerX - 5, playerY));
                CreateBullet(new Vector2(playerX + 5, playerY));
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
        player.GetComponent<Animator>().SetBool("Projectile", true);
        this.transform.position = new Vector2(-10000, 0);
        var falling = GetComponent<FallingPowerUp>();
        falling.enabled = false;
        soundManager.PlayPowerUp();
        timer = Interval;
    }

    public void UnsetPowerUp()
    {
        player.GetComponent<Animator>().SetBool("Projectile", false);
        powerUpManager.DestroyPowerUp(gameObject);
        active = false;
    }
}
