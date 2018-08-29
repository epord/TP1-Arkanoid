using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int MinRandomSteps;
    public int MaxRandomSteps;
    private Animator animator;
    private bool alive = true;
    private long randomWalk = 0;
    private Vector2 currentDirection;
    private RandomManager randomManager;
    private ScoreManager scoreManager;
    private EnemyManager enemyManager;
    private float deathCountDown;
    private SoundManager soundManager;

	// Use this for initialization
	void Start ()
	{
	    animator = GetComponent<Animator>();
        randomManager = GameObject.Find("RandomManager").GetComponent<RandomManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
	
    public void SetAlive()
    {
        alive = true;
    }

	// Update is called once per frame
	void FixedUpdate ()
	{
	    if (alive)
	    {
	        var position = transform.position;
            if (position.y < 0)
	        {
                enemyManager.ReleaseEnemy(gameObject);
	        }
            else
            {
                if (randomWalk == 0)
                {
                    currentDirection = new Vector2(((float)randomManager.GetRandom().NextDouble() - 0.5f) * 2, (float) -randomManager.GetRandom().NextDouble()).normalized;
                    randomWalk = randomManager.GetRandom().Next(MinRandomSteps, MaxRandomSteps);
                }
                else
                {
                    --randomWalk;
                    position.x += currentDirection.x * speed;
                    position.y += currentDirection.y * speed;
                    position.x = Mathf.Clamp(position.x, 20, 200);
                    transform.position = position;
                }
            }
        } else if (deathCountDown > 0)
        {
            deathCountDown--;
            if (deathCountDown == 0)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                enemyManager.ReleaseEnemy(gameObject);
            }
        }
	    
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" || collision.gameObject.name == "player" || collision.gameObject.tag == "projectile")
        {
            alive = false;
            animator.SetBool("Alive", false);
            scoreManager.updateScore(gameObject);
            GetComponent<BoxCollider2D>().enabled = false;
            deathCountDown = 40;
            soundManager.PlayFourthHit();
        }
    }
}
