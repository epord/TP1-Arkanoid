using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject gameOverSprite;
    public GameObject continueSprite;
    public SoundManager soundManager;
    public GameObject player;
    public GameObject ball;
    public GameObject ballPrefab;
    public GameObject[] lifes;
    public string nextScene;

    private GlobalControl globalControl;
    private Vector3 initialBallPosition;
    private Vector3 initialPlayerPosition;
    private bool isGameOver = false;
    public int lifesRemaining = 3;
    private int maxLifes = 3;
    private bool loosingLife = false;
    private bool isDead = false;

    void Start()
    {

        globalControl = GameObject.Find("GlobalControl").GetComponent<GlobalControl>();
        lifesRemaining = globalControl.GetComponent<GlobalControl>().GetLifesRemaining();
        gameOverSprite.GetComponent<Renderer>().enabled = false;
        continueSprite.GetComponent<Renderer>().enabled = false;
        initialPlayerPosition = player.transform.position;
        initialBallPosition = ball.transform.position;
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
        if (isGameOver && isDead)
        {
            if (Input.anyKeyDown)
            {
                globalControl.SetLifesRemaining(maxLifes);
                SceneManager.LoadScene("MenuScene");
            }
        }
        if (loosingLife && Input.anyKeyDown)
        {
            player.GetComponent<Animator>().SetBool("Alive", true);
            continueSprite.GetComponent<Renderer>().enabled = false;
            loosingLife = false;
            player.transform.position = initialPlayerPosition;
            ball = (GameObject)Instantiate(ballPrefab);
            ball.transform.position = initialBallPosition;
            lifesRemaining--;
        }
        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
        {
            if (lifesRemaining == 0)
            {
                if (!isDead)
                {
                    // GAME OVER
                    isDead = true;
                    gameOverSprite.GetComponent<Renderer>().enabled = true;
                    isGameOver = true;
                    player.GetComponent<Animator>().SetBool("Alive", false);
                    soundManager.PlayGameOver();
                }
            } else if (!loosingLife){
                // LIFE LOST
                continueSprite.GetComponent<Renderer>().enabled = true;
                player.GetComponent<Animator>().SetBool("Alive", false);
                lifes[lifesRemaining - 1].SetActive(false);
                soundManager.PlayLifeLost();
                loosingLife = true;
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
