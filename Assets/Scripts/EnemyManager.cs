using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public int MaxEnemies;
    public GameObject EnemyBasePrefab;
    private GameObject[] enemyPool;
	// Use this for initialization
	void Start () {
        enemyPool = new GameObject[MaxEnemies];
        for (int i = 0; i < MaxEnemies; i++)
        {
            enemyPool[i] = Instantiate(EnemyBasePrefab);
            enemyPool[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetEnemy()
    {
        GameObject enemy = null;
        for (int i = 0; i < enemyPool.Length; i++)
        {
            if (enemyPool[i] != null)
            {
                enemy = enemyPool[i];
                enemyPool[i] = null;
                enemy.SetActive(true);
                break;
            }
        }
        return enemy;
    }

    public void ReleaseEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        for (int i = 0; i < enemyPool.Length; i++)
        {
            if (enemyPool[i] == null)
            {
                enemyPool[i] = enemy;
                break;
            }
        }
        return;
    }
}
