using UnityEngine;

public class RandomManager : MonoBehaviour
{
    public int seed = 1;
    private System.Random random;

    void Start ()
    {
		random = new System.Random(seed);
	}

    public System.Random GetRandom()
    {
        return random;
    }
}
