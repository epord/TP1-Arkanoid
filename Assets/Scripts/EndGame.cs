using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public GameObject player;
    public GameObject ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("ball");
        player = GameObject.Find("player");
    }
	
	// Update is called once per frame
	void Update () {
        if(ball.transform.position.y < player.transform.position.y)
        {
            Destroy(player);
            Destroy(ball);
            UnityEditor.EditorUtility.DisplayDialog("End Game", "End Game", "ok", "cancel");
        }
	}
}
