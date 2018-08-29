using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public int lifesRemaining;
    public int score;

	private void Start()
	{
        resetValues();
	}

    public void resetValues()
    {
        lifesRemaining = 3;
        score = 0;
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

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }
}