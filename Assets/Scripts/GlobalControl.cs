using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public int lifesRemaining;

	private void Start()
	{
        lifesRemaining = 3;
	}

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
        return this.lifesRemaining;
    }

    public void SetLifesRemaining(int lifes)
    {
        this.lifesRemaining = lifes;
    }
}