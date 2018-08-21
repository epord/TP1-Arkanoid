using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {

    public GameObject bonusObject;
    public int hp;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
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
