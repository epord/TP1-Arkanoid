using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager : MonoBehaviour {
    public int seed = 1;
    private System.Random random;
    // Use this for initialization
    void Start () {
		random = new System.Random(seed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public System.Random GetRandom()
    {
        return random;
    }
}
