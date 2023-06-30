using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Entities.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    [SerializeField] int damage;
    bool isFirstCollision = true;

    private void OnTriggerEnter(Collider other)
    {
        //if (isFirstCollision)
        //{
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerModel>().HealthController.TakeDamage(damage); //TODO Paso a damage state
            other.gameObject.GetComponent<EntityModel>().IsDamaged = true;
            other.gameObject.GetComponent<EntityModel>().StartingRutine();


        
        }
        else if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyModel>().HealthController.TakeDamage(damage);
            other.gameObject.GetComponent<EntityModel>().IsDamaged = true;
            other.gameObject.GetComponent<EntityModel>().StartingRutine();
        }
        else if (other.gameObject.tag == "Boss")
        {
            if(!other.gameObject.GetComponent<BossEnemyModel>().GetData().IsInvulnerable)
            {
                //other.gameObject.GetComponent<BossEnemyModel>().HealthController.TakeDamage(damage);
                other.gameObject.GetComponent<BossEnemyModel>().GetDamage(damage);
                other.gameObject.GetComponent<EntityModel>().IsDamaged = true;
            }
        }
        //    isFirstCollision = false;
        //}
    }
}
