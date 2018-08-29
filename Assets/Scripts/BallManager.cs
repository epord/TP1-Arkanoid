using UnityEngine;

public class BallManager : MonoBehaviour {
    public long MaxBalls = 10;
    public GameObject baseBallPrefab;
    private GameObject[] balls;

	void Start () {
        balls = new GameObject[MaxBalls];
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i] = Instantiate(baseBallPrefab);
            balls[i].SetActive(false);
            balls[i].tag = "InactiveBall";
        }
	}

    public GameObject GetBall()
    {
        GameObject ball = null;
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls[i] != null)
            {
                ball = balls[i];
                balls[i] = null;
                ball.SetActive(true);
                ball.tag = "Ball";
                break;
            }
        }
        return ball;
    }

    public void ReleaseBall(GameObject ball)
    {
        ball.SetActive(false);
        ball.tag = "InactiveBall";
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls[i] == null)
            {
                balls[i] = ball;
                break;
            }
        }
        return;
    }
}
