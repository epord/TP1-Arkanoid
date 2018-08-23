using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject gameOverSprite;
    public GameObject continueSprite;
    public SoundManager soundManager;
    public GameObject player;

    private bool isGameOver = false;
    private float flickeringTime = 0.3f;
    private float timer = 0.0f;
    private const float EPSILON = 0.001f;

    void Start()
    {
        //Instantiate(soundManager);
        Time.timeScale = 1;
        gameOverSprite.GetComponent<Renderer>().enabled = false;
        continueSprite.GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
    void Update () {
        if (isGameOver)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            timer = Mathf.Min(timer + Time.deltaTime, 0.3f);
            if (timer - 0.3f < EPSILON) {
                timer = 0.0f;
                continueSprite.GetComponent<Renderer>().enabled = !continueSprite.GetComponent<Renderer>().enabled;
            }

        }
        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
		{
            // GAME OVER
            gameOverSprite.GetComponent<Renderer>().enabled = true;
            continueSprite.GetComponent<Renderer>().enabled = true;
            //Time.timeScale = 0;
            isGameOver = true;
            player.GetComponent<Animator>().SetBool("Alive", false);
        }
		if (GameObject.FindGameObjectsWithTag("Brick").Length == 0)
		{
			// WIN
		}
	}
}
