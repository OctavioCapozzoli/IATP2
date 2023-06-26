using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileSpeed;

    private void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("bocchi za rocku");
        }
        Destroy(gameObject);
    }
}
