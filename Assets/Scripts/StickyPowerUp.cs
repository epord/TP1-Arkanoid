using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPowerUp : MonoBehaviour {
    private Vector2 temp;
    public float timer = 10;
    private bool active;
    private GameObject[] balls;
    private void Start()
    {
    }

    public void Update()
    {
        if (active) {
            timer = Mathf.Max(timer - Time.deltaTime, 0);
            if (timer == 0)
            {
                foreach (var ball in balls)
                {
                    var ballMove = ball.GetComponent<Ball_move>();
                    ballMove.NoStickMode();
                }
                Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.name == "player")
        {
            balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (var ball in balls)
            {
                ball.GetComponent<Ball_move>().SetStickMode();
            }
            this.transform.position = new Vector2(-10000, 0);
            var falling = GetComponent<FallingPowerUp>();
            Destroy(falling);
            active = true;
            
            //gameObject.SetActive(false);
        }
    }
}
