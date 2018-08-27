using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBallPowerUp : MonoBehaviour
{
    public int MaxBallsAllowed = 9;
    private GameObject player;
    private SoundManager soundManager;
    private ScoreManager scoreManager;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("player");
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.updateScore(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CopyBall(GameObject ball, Vector2 direction)
    {
        var ballCopy = Instantiate(ball);
        var ballCopyBallMove = ballCopy.GetComponent<Ball_move>();
        ballCopyBallMove.initialDir = direction;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            var balls = GameObject.FindGameObjectsWithTag("Ball");
            if (balls.Length < MaxBallsAllowed / 3)
            {
                foreach (var ball in balls)
                {
                    CopyBall(ball, new Vector2(0, 1).normalized);
                    CopyBall(ball, new Vector2(1, 1).normalized);
                }
            }
            
            soundManager.PlayPowerUp();
            Destroy(this.gameObject);
        }
    }
}
