using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour {

    private GameObject ball;
    private Vector2 temp;
    public float timer = 10;
    private bool active;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public void Update()
    {
        if (active) {
            timer = Mathf.Max(timer - Time.deltaTime, 0);
            if (timer == 0)
            {
                var ballMove = ball.GetComponent<Ball_move>();
                ballMove.NoStickMode();

                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo) // difference with isTrigger ? 
    {
        if (collisionInfo.gameObject.name == "player")
        {
            var falling = GetComponent<FallingPowerUp>();
            Destroy(falling);
            active = true;
            ball.GetComponent<Ball_move>().SetStickMode();
            this.transform.position = new Vector2(-10000, 0);
            //gameObject.SetActive(false);
        }
    }
}
