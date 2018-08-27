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

	// Use this for initialization
	void Start ()
	{
	    animator = GetComponent<Animator>();
	    randomManager = GameObject.Find("RandomManager").GetComponent<RandomManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    if (alive)
	    {
	        var position = transform.position;
            if (position.y < 0)
	        {
                Destroy(gameObject);
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
        }
	    
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" || collision.gameObject.name == "player")
        {
            alive = false;
            animator.SetBool("Alive", false);
            scoreManager.updateScore(gameObject);
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
