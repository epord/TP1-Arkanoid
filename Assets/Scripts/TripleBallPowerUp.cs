using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBallPowerUp : MonoBehaviour
{
    public int MaxBallsAllowed = 9;
    private GameObject player;
    private SoundManager soundManager;
    private ScoreManager scoreManager;
    private BallManager ballManager;
    private PowerUpManager powerUpManager;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("player");
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        ballManager = GameObject.Find("BallManager").GetComponent<BallManager>();
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
        scoreManager.updateScore(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CopyBall(GameObject ball, Vector2 direction)
    {
        var ballCopy = ballManager.GetBall();
        if (ballCopy != null)
        {
            ballCopy.transform.position = ball.transform.position;
            var ballCopyBallMove = ballCopy.GetComponent<Ball_move>();
            ballCopyBallMove.StartMoving(direction);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            var balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (var ball in balls)
            {
                CopyBall(ball, new Vector2(0, 1).normalized);
                CopyBall(ball, new Vector2(1, 1).normalized);
            }
            
            soundManager.PlayPowerUp();
            powerUpManager.DestroyPowerUp(gameObject);
        }
    }
}
