using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    
    private SoundManager soundManager;
    public int hp;
    public double dropRate = 0.10;
    public bool Indestructible;
    private RandomManager randomManager;
    private PowerUpManager powerUpManager;
    private ScoreManager scoreManager;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        randomManager = GameObject.Find("RandomManager").GetComponent<RandomManager>();
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if (Indestructible)
        {
            gameObject.tag = "indestructible_block";
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {

        if(hp == 1)
        {
            soundManager.PlayFirstHit();
        }else if(hp == 2)
        {
            soundManager.PlaySecondHit();
        }else if(hp == 3)
        {
            soundManager.PlayThirdHit();
        }else if(hp == 4)
        {
            soundManager.PlayFourthHit();
        }

        if (randomManager.GetRandom().NextDouble() < dropRate)
        {
            var powerUp = powerUpManager.RandomPowerUp();
            if (powerUp != null)
            {
                //bonus.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                powerUp.transform.position = transform.position;
                powerUp.transform.rotation = transform.rotation;
            }
            
        }

        if (!Indestructible)
        {
            hp--;
            if (hp <= 0)
            {
                scoreManager.updateScore(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
