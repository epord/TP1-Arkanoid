using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minLength : MonoBehaviour
{

    private GameObject player;
    private bool active;
    public float timer = 10;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            timer = Mathf.Max(timer - Time.deltaTime, 0);
            if (timer == 0)
            {
                player.GetComponent<mover>().setLongMode();

                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.name == "player")
        {
            var falling = GetComponent<FallingPowerUp>();
            Destroy(falling);
            active = true;
            player.GetComponent<mover>().unSetLongMode();
            this.transform.position = new Vector2(-10000, 0);
        }
    }
}
