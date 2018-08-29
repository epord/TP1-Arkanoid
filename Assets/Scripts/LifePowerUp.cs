using UnityEngine;

public class LifePowerUp : MonoBehaviour {

    private GameManager gameManager;
    private SoundManager soundManager;
    private PowerUpManager powerUpManager;

    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
    }
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            gameManager.AddLife();
            soundManager.PlayPowerUp();
            powerUpManager.DestroyPowerUp(gameObject);
        }
    }
}
