using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        if (GameObject.FindWithTag("Player"))
        {
            var playerGO = GameObject.FindWithTag("Player");
            playerGO.transform.position = transform.position;
        }
    }
}
