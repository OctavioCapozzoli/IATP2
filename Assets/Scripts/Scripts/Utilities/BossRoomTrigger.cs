using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.tag);
        if (other.tag == "Player")
        {
            GameObject.FindWithTag("Boss").gameObject.GetComponent<BossEnemyModel>().GetData().IsInBossRoom = true;
            Destroy(this.gameObject, 1.5f);
        }
    }
}
