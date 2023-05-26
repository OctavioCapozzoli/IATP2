using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    string target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == target)
        {
            //TODO damage cuando colisiona attack collider
        }
    }
}
