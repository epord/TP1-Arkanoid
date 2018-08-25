using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject gameOverSprite;
    public GameObject continueSprite;
    public SoundManager soundManager;
    public GameObject player;

    public bool isPlaying;
    private bool isGameOver = false;
    private float flickeringTime = 0.3f;
    private float timer = 0.0f;
    private const float EPSILON = 0.001f;
    private string playingScene = "Level1";
    private string menuScene = "MenuScene";

    void Start()
    {
        if (SceneManager.GetActiveScene().name == playingScene)
        {
            isPlaying = true;
        }
        else if (SceneManager.GetActiveScene().name == menuScene)
        {
            isPlaying = false;
        }
        gameOverSprite.GetComponent<Renderer>().enabled = false;
        continueSprite.GetComponent<Renderer>().enabled = false;
    }
	
    void Update () {
        if (isPlaying == false)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(playingScene);
                isPlaying = true;
            }
        }
        else
        {
            if (isGameOver)
            {
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
            {
                // GAME OVER
                gameOverSprite.GetComponent<Renderer>().enabled = true;
                continueSprite.GetComponent<Renderer>().enabled = true;
                isGameOver = true;
                player.GetComponent<Animator>().SetBool("Alive", false);
            }
            if (GameObject.FindGameObjectsWithTag("Brick").Length == 0)
            {
                // WIN
            }
        }
    }
        
}
