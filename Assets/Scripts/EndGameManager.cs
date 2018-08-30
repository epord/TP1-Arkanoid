using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour {

    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private GameManager gameManager;
    private bool oneTime = false;

	void Start ()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundManager.PlayTitleScreen();
        gameManager.isOnEndingScreen = true;
	}

    private void Update()
    {
        if (!oneTime)
        {
            if (scoreManager.GetNewHighScore())
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            oneTime = true;
        }
    }
}
