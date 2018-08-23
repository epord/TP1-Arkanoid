using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject gameOverSprite;
    public GameObject continueSprite;
    public SoundManager soundManager;

    private bool isPlaying;
    private bool isGameOver = false;
    private float flickeringTime = 0.3f;
    private float timer = 0.0f;
    private const float EPSILON = 0.001f;
    private string playingScene = "Graphic_test_scene";
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
        Time.timeScale = 1;
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
                timer = Mathf.Min(timer + Time.deltaTime, 0.3f);
                if (timer < 0.2f)
                {
                    timer = 0.0f;
                    continueSprite.GetComponent<Renderer>().enabled = !continueSprite.GetComponent<Renderer>().enabled;
                }

            }
            if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
            {
                // GAME OVER
                gameOverSprite.GetComponent<Renderer>().enabled = true;
                continueSprite.GetComponent<Renderer>().enabled = true;
                Time.timeScale = 0;
                isGameOver = true;
            }
            if (GameObject.FindGameObjectsWithTag("Brick").Length == 0)
            {
                // WIN
            }
        }
    }
        
}
