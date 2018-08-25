using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    
    private SoundManager soundManager;
    public int hp;
    public double dropRate = 0.10;
    private RandomManager randomManager;
    private PowerUpManager powerUpManager;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        randomManager = GameObject.Find("RandomManager").GetComponent<RandomManager>();
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
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

        hp--;

        if(hp <= 0)
        {
            if (randomManager.GetRandom().NextDouble() < dropRate)
            {
                var bonus = Instantiate(powerUpManager.RandomPowerUp());
                //bonus.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                bonus.transform.position = transform.position;
                bonus.transform.rotation = transform.rotation;
            }
            Destroy(gameObject);    
        }
        
    }
}
