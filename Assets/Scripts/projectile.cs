using UnityEngine;

public class projectile : MonoBehaviour
{
    public float MaxHeight = 236;
    public float speed;
    private ProjectilePowerUp projectilePowerUp;

    void Start()
    {
        ResetVelocity();
    }

    public void ResetVelocity()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    public void SetProjectilePowerUp(ProjectilePowerUp projectilePowerUp)
    {
        this.projectilePowerUp = projectilePowerUp;
    }

    void Update()
    {
        if (transform.position.y >= MaxHeight)
        {
            projectilePowerUp.DestroyBullet(gameObject);
        }
    }

    private void OnCollisionEnter2D() 
    {
        projectilePowerUp.DestroyBullet(gameObject);
    }

    

}
