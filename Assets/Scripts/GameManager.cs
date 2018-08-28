using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject gameOverSprite;
    public GameObject continueSprite;
    public SoundManager soundManager;
    public GlobalControl globalControl;
    public GameObject player;
    public GameObject ball;
    public GameObject ballPrefab;
    public GameObject[] lifes;
    public string nextScene;

    private Vector3 initialBallPosition;
    private Vector3 initialPlayerPosition;
    private bool isGameOver = false;
    public int lifesRemaining;
    private int maxLifes = 3;

    void Start()
    {
        lifesRemaining = globalControl.GetComponent<GlobalControl>().GetLifesRemaining();
        gameOverSprite.GetComponent<Renderer>().enabled = false;
        continueSprite.GetComponent<Renderer>().enabled = false;
        initialPlayerPosition = player.transform.position;
        initialBallPosition = ball.transform.position;

        lifesRemaining = globalControl.GetComponent<GlobalControl>().GetLifesRemaining();
        for (int i = lifesRemaining; i < maxLifes; i++)
        {
            lifes[i].SetActive(false);
        }
    }
	
    public void addLife()
    {
        if (lifesRemaining < maxLifes) {
            lifes[lifesRemaining].SetActive(true);
            lifesRemaining++;
        }
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MenuScene");
        }
        if (isGameOver)
        {
            if (Input.anyKeyDown)
            {
                globalControl.SetLifesRemaining(maxLifes);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
        {
            if (lifesRemaining == 0)
            {
                // GAME OVER
                gameOverSprite.GetComponent<Renderer>().enabled = true;
                continueSprite.GetComponent<Renderer>().enabled = true;
                isGameOver = true;
                player.GetComponent<Animator>().SetBool("Alive", false);
                soundManager.PlayGameOver();
            } else {
                // LIFE LOST
                lifes[lifesRemaining-- - 1].SetActive(false);
                player.transform.position = initialPlayerPosition;
                ball = (GameObject)Instantiate(ballPrefab);
                ball.transform.position = initialBallPosition;
                soundManager.PlayLifeLost();
            }
        }
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 0 || Input.GetKeyDown(KeyCode.Q))
        {
            // WIN
            globalControl.SetLifesRemaining(lifesRemaining);
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        }
    }
        
}
