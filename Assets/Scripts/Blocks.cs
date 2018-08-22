using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {

    public GameObject bonusObject;
    private SoundManager soundManager;
    public int hp;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
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
            if (bonusObject != null)
            {
                var bonus = Instantiate(bonusObject);
                //bonus.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                bonus.transform.position = transform.position;
                bonus.transform.rotation = transform.rotation;
            }
            Destroy(gameObject);    
        }
        
    }
}
