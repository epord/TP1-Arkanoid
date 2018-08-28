using System.Collections;
using System.Collections.Generic;
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

	// Use this for initialization
	void Start () {
		powerUps = new GameObject[]
		{
            stickyPowerUp,
            maxLengthPowerUp,
            minLengthPowerUp,
            projectilePowerUp,
            triplePowerUp,
            lifePowerUp,
		};

        randomManager = GameObject.Find("RandomManager").GetComponent<RandomManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Called when a power up's timer is up or a new power up replaces it.
    public void ReleasePowerUp()
    {
        currentPowerUp.UnsetPowerUp();
        currentPowerUp = null;
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
        return powerUps[i];
    }
}
