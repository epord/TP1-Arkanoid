using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public int lifesRemaining = 3;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public int GetLifesRemaining()
    {
        return lifesRemaining;
    }

    public void SetLifesRemaining(int lifes)
    {
        lifesRemaining = lifes;
    }
}