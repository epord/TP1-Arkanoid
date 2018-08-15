using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPowerUp : MonoBehaviour {


    public float speed = 50;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        transform.position = temp;
    }
}
