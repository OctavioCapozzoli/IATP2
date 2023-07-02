using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float projectileSpeed;
    public float damage;
    float lifetime = 2f, timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(this.gameObject);
        }
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = this.transform.forward * projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyModel>().HealthController.TakeDamage(damage);
            other.gameObject.GetComponent<EntityModel>().IsDamaged = true;
        }
        Destroy(gameObject);
    }
}
