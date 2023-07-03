using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Entities.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseballBat : MonoBehaviour
{
    [SerializeField] int damage;
    bool isFirstCollision = true;

    private void OnTriggerEnter(Collider other)
    {
        if (isFirstCollision)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerModel>().HealthController.TakeDamage(damage); //TODO Paso a damage state
                Debug.Log("Player was damaged, current health is: " + other.gameObject.GetComponent<PlayerModel>().HealthController.CurrentHealth);
                other.gameObject.GetComponent<EntityModel>().StartingRutine();
                //other.gameObject.GetComponent<PlayerModel>().IsDamaged = true;
            }

            isFirstCollision = false;
        }
    }
}
