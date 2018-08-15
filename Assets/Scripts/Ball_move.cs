﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_move : MonoBehaviour {

    public GameObject player;
    public float initialSpeed = 200;
    public float slowMultiplier = 0.5f;
    private float speed;
    private float stickyOffset;
    public bool stickMode;
    private bool sticked;
    private Vector2 oldDir;
    // Use this for initialization
    void Start () {
        speed = initialSpeed;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            float dir = ballBounceDir(collision.transform.position, transform.position, collision.collider.bounds.size.x);

            Vector2 newDir = new Vector2(dir, 1).normalized;
            if (stickMode)
            {
                speed = 0;
                sticked = true;
                stickyOffset = this.transform.position.x - player.transform.position.x;
                oldDir = newDir;
            }
            GetComponent<Rigidbody2D>().velocity = newDir * speed;
        }   
        
    }



    private float ballBounceDir(Vector2 player, Vector2 ball, float playerSize)
    {
        return (ball.x - player.x)/playerSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (sticked)
        {
            var temp = this.transform.position;
            temp.x = player.transform.position.x + stickyOffset;
            this.transform.position = temp;
        }
    }

    public void SetStickMode()
    {
        stickMode = true;
        sticked = false;
    }

    public void NoStickMode()
    {
        stickMode = false;
        sticked = false;
        speed = initialSpeed;
        stickyOffset = 0;
        GetComponent<Rigidbody2D>().velocity = oldDir * speed;
    }
}