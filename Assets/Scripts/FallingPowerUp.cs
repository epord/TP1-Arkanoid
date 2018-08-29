using UnityEngine;

public class FallingPowerUp : MonoBehaviour {
    public float speed = 50;
    private PowerUpManager powerUpManager;

    void Start () {
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
    }
	
	void Update () {
        var temp = transform.position;
	    if (temp.y < 0)
	    {
            powerUpManager.DestroyPowerUp(gameObject);
	    }
	    else
	    {
	        temp.y -= speed * Time.deltaTime;
	        transform.position = temp;
        }
    }
}
