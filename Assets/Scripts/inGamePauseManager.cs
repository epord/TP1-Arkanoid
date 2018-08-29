using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGamePauseManager : MonoBehaviour
{

    private bool isGamePaused = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isGamePaused)
            {
                Time.timeScale = 0;
                GetComponent<SpriteRenderer>().enabled = true;
                isGamePaused = true;
            }
            else
            {
                Time.timeScale = 1;
                GetComponent<SpriteRenderer>().enabled = false;
                isGamePaused = false;
            }
        }
    }
}