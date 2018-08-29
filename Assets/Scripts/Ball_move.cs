using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_move : MonoBehaviour {

    private GameObject player;
    public float leftBound = 0;
    public float rightBound = 200;
    public float initialSpeed = 200;
    public float slowMultiplier = 0.5f;
    public float speed = 0;
    private float stickyOffset;
    public bool stickMode;
    private bool sticked;
    private Vector2 oldDir;
    public Vector2 initialDir = Vector2.up;
    private SoundManager soundManager;
    public bool gameStarted = false;
    private BallManager ballManager;

    void Start () {
        //speed = 0;
        player = GameObject.Find("player");
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        ballManager = GameObject.Find("BallManager").GetComponent<BallManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            float dir = ballBounceDir(collision.transform.position, transform.position, collision.collider.bounds.size.x);

            Vector2 newDir = new Vector2(dir, 1).normalized;
            if (stickMode)
            {
                speed = 0;
                sticked = true;
                stickyOffset = this.transform.position.x - player.transform.position.x;
            }
            oldDir = newDir;
            GetComponent<Rigidbody2D>().velocity = newDir * speed;
            var position = transform.position;
            position.y = collision.gameObject.transform.position.y + collision.otherCollider.bounds.size.y;
            transform.position = position;

            soundManager.PlayCollisionPlayerBall();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().velocity = oldDir * speed;
    }

    public void StartMoving(Vector2 direction) {
        speed = initialSpeed;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        gameStarted = true;
    }

    private float ballBounceDir(Vector2 player, Vector2 ball, float playerSize)
    {
        return (ball.x - player.x)/playerSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            Vector3 pos = this.transform.position;
            pos.x = player.transform.position.x;
            this.transform.position = pos;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                speed = initialSpeed;
                GetComponent<Rigidbody2D>().velocity = initialDir * speed;
                gameStarted = true;
            }
        }

        if (transform.position.y < 0)
        {
            ballManager.ReleaseBall(gameObject);
        }
    }

    void LateUpdate()
    {
        
        if (sticked)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                sticked = false;
                speed = initialSpeed;
                stickyOffset = 0;
                GetComponent<Rigidbody2D>().velocity = oldDir * speed;
            }
            else
            {
                var temp = this.transform.position;
                temp.x = player.transform.position.x + stickyOffset;
                temp.x = Mathf.Clamp(temp.x, leftBound, rightBound);
                this.transform.position = temp;
            }
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
        if (sticked)
        {
            sticked = false;
            speed = initialSpeed;
            stickyOffset = 0;
            GetComponent<Rigidbody2D>().velocity = oldDir * speed;
        }
        
    }
}
