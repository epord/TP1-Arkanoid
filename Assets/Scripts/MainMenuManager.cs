using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public string firstScene;
    private SoundManager soundManager;
    private bool isPlaying = false;
    private GlobalControl globalControl;

	void Start () {
        globalControl = GameObject.Find("GlobalControl").GetComponent<GlobalControl>();
        globalControl.SetLifesRemaining(3);
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        soundManager.PlayTitleScreen();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(firstScene);
        }
	}
}
