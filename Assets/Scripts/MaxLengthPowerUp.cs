using UnityEngine;

public class MaxLengthPowerUp : MonoBehaviour, PowerUp
{
    private GameObject player;
    private bool active;
    public float Interval = 10;
    private float timer;
    private SoundManager soundManager;
    private PowerUpManager powerUpManager;
    private ScoreManager scoreManager;

	void Start ()
    {
        player = GameObject.Find("player");
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
	    powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.updateScore(gameObject);
    }
	
	void Update ()
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

    public void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.name == "player")
        {
            SetPowerUp();
        }
    }

    public void SetPowerUp()
    {
        powerUpManager.SetPowerUp(this);
        player.GetComponent<mover>().SetLongMode();
        var falling = GetComponent<FallingPowerUp>();
        falling.enabled = false;
        active = true;
        this.transform.position = new Vector2(-10000, 0);
        soundManager.PlayPowerUp();
        timer = Interval;
    }

    public void UnsetPowerUp()
    {
        player.GetComponent<mover>().UnsetLongMode();
        powerUpManager.DestroyPowerUp(gameObject);
        active = false;
    }

}
