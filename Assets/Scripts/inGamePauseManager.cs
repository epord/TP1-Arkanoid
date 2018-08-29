using UnityEngine;

public class inGamePauseManager : MonoBehaviour
{
    private bool isGamePaused = false;

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