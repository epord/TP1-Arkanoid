using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public SoundManager soundManager;

	// Use this for initialization
	void Start () {
        Instantiate(soundManager);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
		{
			// GAME OVER
		}
		if (GameObject.FindGameObjectsWithTag("Brick").Length == 0)
		{
			// WIN
		}
		
	}
}
