using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BocchiFireBallScript : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject fireball = Instantiate(projectile, transform) as GameObject;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
        }
    }
}
