using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Entities.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float gizmosRadius;

    private void OnTriggerEnter(Collider other)
    {
        //if (isFirstCollision)
        //{
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerModel>().HealthController.TakeDamage(damage); //TODO Paso a damage state
            Debug.Log("Player was damaged, current health is: " + other.gameObject.GetComponent<PlayerModel>().HealthController.CurrentHealth);  
            other.gameObject.GetComponent<EntityModel>().StartingRutine();
            //other.gameObject.GetComponent<PlayerModel>().IsDamaged = true;
        }
       else if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyModel>().HealthController.TakeDamage(damage);
            Debug.Log("Enemy was damaged, current health is: " + other.gameObject.GetComponent<EnemyModel>().HealthController.CurrentHealth);
            other.gameObject.GetComponent<EntityModel>().IsDamaged = true;
            other.gameObject.GetComponent<EntityModel>().StartingRutine();
        }
        else if (other.gameObject.tag == "Boss")
        {
            //other.gameObject.GetComponent<BossEnemyModel>().HealthController.TakeDamage(damage);
            other.gameObject.GetComponent<BossEnemyModel>().GetDamage(damage);
            Debug.Log("Enemy was damaged, current health is: " + other.gameObject.GetComponent<BossEnemyModel>().HealthController.CurrentHealth);
            other.gameObject.GetComponent<EntityModel>().IsDamaged = true;
        }
        //    isFirstCollision = false;
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, gizmosRadius);
    }
}
