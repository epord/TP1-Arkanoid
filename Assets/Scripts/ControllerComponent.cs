using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerComponent : MonoBehaviour {
    
    public Vector2 movement = new Vector2(0, 0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            movement.Set(-1, 0);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            movement.Set(1, 0); 
        } else {
            movement.Set(0, 0);
        }
	}
}
