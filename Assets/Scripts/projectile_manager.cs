using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_manager : MonoBehaviour {

    public GameObject projectile1;
    //public GameObject projectile2;

    void Start ()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletRight = Instantiate(projectile1, transform.position, transform.rotation) as GameObject;
            //GameObject bulletLeft = Instantiate(projectile2, projectile2.transform.position, projectile2.transform.rotation) as GameObject;
            bulletRight.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            //bulletLeft.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            Destroy(bulletRight, 2);
            //Destroy(bulletLeft, 2);
        }
    }
}
