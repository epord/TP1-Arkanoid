using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float speed;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    private void OnBecameInvisible() // NOT WORKING ???
    {
        Debug.Log("onbecameinvisible");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D() 
    {
        Destroy(gameObject);
    }

    

}
