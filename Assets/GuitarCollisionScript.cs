using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Entities.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarCollisionScript : MonoBehaviour
{
    [SerializeField] int damage;
    bool isFirstCollision = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entro a trigger enter guitar");
        if (isFirstCollision)
        {
            if (other.gameObject.tag == "Boss")
            {
                other.gameObject.GetComponent<BossEnemyModel>().GetDamage(damage); //TODO Paso a damage state
                Debug.Log("Boss was damaged, current health is: " + other.gameObject.GetComponent<BossEnemyModel>().HealthController.CurrentHealth);
                other.gameObject.GetComponent<BossEnemyModel>().StartingRutine();
                //other.gameObject.GetComponent<PlayerModel>().IsDamaged = true;
            }
            else if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyModel>().GetDamage(damage); //TODO Paso a damage state
                Debug.Log("Enemy was damaged, current health is: " + other.gameObject.GetComponent<EnemyModel>().HealthController.CurrentHealth);
                other.gameObject.GetComponent<EnemyModel>().StartingRutine();
            }

            isFirstCollision = false;
        }
    }
}
