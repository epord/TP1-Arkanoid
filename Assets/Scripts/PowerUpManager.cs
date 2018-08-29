using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private PowerUp currentPowerUp;
    public GameObject stickyPowerUp;
    public GameObject maxLengthPowerUp;
    public GameObject minLengthPowerUp;
    public GameObject projectilePowerUp;
    public GameObject triplePowerUp;
    public GameObject lifePowerUp;
    private GameObject[] powerUps;
    private RandomManager randomManager;

	void Start ()
    {
		powerUps = new GameObject[]
		{
            Instantiate(stickyPowerUp),
            Instantiate(maxLengthPowerUp),
            Instantiate(minLengthPowerUp),
            Instantiate(projectilePowerUp),
            Instantiate(triplePowerUp),
            Instantiate(lifePowerUp),
		};

	    foreach (var powerup in powerUps)
	    {
            powerup.SetActive(false);
	    }

        randomManager = GameObject.Find("RandomManager").GetComponent<RandomManager>();
    }

    // Called when a power up's timer is up or a new power up replaces it.
    public void ReleasePowerUp()
    {
        currentPowerUp.UnsetPowerUp();
        currentPowerUp = null;
    }

    public void DestroyPowerUp(GameObject powerUp)
    {
        powerUp.SetActive(false);
        for (int i = 0; i < powerUps.Length; i++)
        {
            if (powerUps[i] == null)
            {
                powerUps[i] = powerUp;
                break;
            }
        }
    }

    // Called when a new power up appears.
    public void SetPowerUp(PowerUp powerUp)
    {
        if (currentPowerUp != null)
        {
            ReleasePowerUp();
        }
        currentPowerUp = powerUp;
    }


    public GameObject RandomPowerUp()
    {
        var i = randomManager.GetRandom().Next(0, powerUps.Length);
        var originalDraw = i;
        var powerUp = powerUps[i];
        while (powerUp == null)
        {
            i = i == powerUps.Length - 1 ? 0 : i + 1;
            if (i == originalDraw)
            {
                break;
            }
            else
            {
                powerUp = powerUps[i];
            }
        }

        if (powerUp != null)
        {
            powerUps[i] = null;
            powerUp.SetActive(true);
            powerUp.GetComponent<FallingPowerUp>().enabled = true;
        }

        return powerUp;
    }
}
