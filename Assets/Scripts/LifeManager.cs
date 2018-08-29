using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int lifesRemaining = 3;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    int getLifesRemaining()
    {
        return lifesRemaining;
    }
}
