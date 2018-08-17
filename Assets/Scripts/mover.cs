using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mover : MonoBehaviour {

    public float speed = 150;
    public GameObject projectile1;
    public bool longMode;
    public bool shortMode;
    private Image m_Image;
    private BoxCollider2D m_BoxCollider2D;
    private Transform m_Transform;
    public Sprite normalSprite;
    public Sprite longSprite;
    public Sprite shortSprite;
    private float const_modifyLength = 0.5f;

    // Use this for initialization
    void Start () {
        m_Image = GetComponent<Image>();
        m_Transform = GetComponent<Transform>();
        m_BoxCollider2D = GetComponent<BoxCollider2D>();
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

        // Direction and speed
        float h = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }

    public void setLongMode()
    {
        longMode = true;
        //Update image and size of both transform and Boxcollider
        m_Image.sprite = longSprite;
        var temp = m_Transform.localScale;
        temp.x += const_modifyLength;
        m_Transform.localScale = temp;
        temp = m_BoxCollider2D.size;
        temp.x += const_modifyLength;
        m_BoxCollider2D.size = temp;
    }

    public void unSetLongMode()
    {
        longMode = false;
        //Update image and size of both transform and Boxcollider
        m_Image.sprite = shortSprite;
        var temp = m_Transform.localScale;
        temp.x -= const_modifyLength;
        m_Transform.localScale = temp;
        temp = m_BoxCollider2D.size;
        temp.x -= const_modifyLength;
        m_BoxCollider2D.size = temp;
    }
}
