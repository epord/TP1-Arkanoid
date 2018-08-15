using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {

    public float speed = 150;
    public GameObject projectile1;

    // Use this for initialization
    void Start () {
		
	}

    //// Update is called once per frame
    //void Update () {
    //       if (Input.GetKey(KeyCode.LeftArrow))
    //       {
    //           Vector3 position = this.transform.position;
    //           position.x--;
    //           this.transform.position = position;
    //       }
    //       if (Input.GetKey(KeyCode.RightArrow))
    //       {
    //           Vector3 position = this.transform.position;
    //           position.x++;
    //           this.transform.position = position;
    //       }
    //   }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float playerX = transform.position.x;
            float playerY = transform.position.y + 5;

            var bullet = Instantiate(projectile1);
            bullet.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            bullet.transform.position = new Vector2(playerX, playerY);
            bullet.transform.rotation = transform.rotation;
            Destroy(bullet, 2);
        }

        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal");

        // Set Velocity (movement direction * speed)
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }

    void FixedUpdate()
    {
        
    }
}
