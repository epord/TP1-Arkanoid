using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {
    public int lifesRemaining = 3;

    void Awake()
    {
        // Do not destroy this game object:
        DontDestroyOnLoad(this);
    }

    int getLifesRemaining()
    {
        return lifesRemaining;
    }
}
