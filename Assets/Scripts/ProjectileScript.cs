using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileSpeed;
    public float damage;

    private void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyModel>().HealthController.TakeDamage(damage);
            Debug.Log("Enemy was damaged, current health is: " + other.gameObject.GetComponent<EnemyModel>().HealthController.CurrentHealth);
            other.gameObject.GetComponent<EntityModel>().IsDamaged = true;
        }
        Destroy(gameObject);
    }
}
