using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public long EnemySpawnInterval;
    public long CloseInterval;
    public GameObject Enemy;
    private long enemySpawnCountdown;
    private long closeCountdown = 0;
    private Animator animator;

	// Use this for initialization
	void Start ()
	{
	    animator = GetComponent<Animator>();
	    enemySpawnCountdown = EnemySpawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
	    if (closeCountdown > 0)
	    {
	        closeCountdown--;
	        if (closeCountdown == 0)
	        {
                animator.SetBool("Open", false);
	            enemySpawnCountdown = EnemySpawnInterval;
	        }
	    }
        else if (enemySpawnCountdown > 0)
	    {
	        enemySpawnCountdown--;
	        if (enemySpawnCountdown == 0)
	        {
	            // Spawn an enemy

	            animator.SetBool("Open", true);
	            var enemy = Instantiate(Enemy);
	            enemy.transform.position = transform.position;
	            closeCountdown = CloseInterval;
	        }
        }
	}
}
