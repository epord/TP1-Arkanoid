using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mover : MonoBehaviour {

    public float speed = 150;

    // Very hacky trick to update the boxcollider size one frame after the animation has changed
    private int nextFrameReset;
    
    // Use this for initialization
    void Start () {
	}

    private void FixedUpdate()
    {
        // Direction and speed
        float h = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed ;
    }

    void LateUpdate()
    {
        if (nextFrameReset == 1)
        {
            ResetSize();
        }
        if (nextFrameReset > 0)
        {
            nextFrameReset--;
        }
    }

    public void SetLongMode()
    {
        GetComponent<Animator>().SetBool("Long", true);
        nextFrameReset = 2;
    }

    public void UnsetLongMode()
    {
        GetComponent<Animator>().SetBool("Long", false);
        nextFrameReset = 2;
    }

    private void ResetSize()
    {
        var newSize = GetComponent<SpriteRenderer>().bounds.size;
        GetComponent<BoxCollider2D>().size = newSize;

    }

    public void SetShortMode()
    {
        GetComponent<Animator>().SetBool("Short", true);
        nextFrameReset = 2;
    }

    public void UnsetShortMode()
    {
        GetComponent<Animator>().SetBool("Short", false);
        nextFrameReset = 2;
    }

}
