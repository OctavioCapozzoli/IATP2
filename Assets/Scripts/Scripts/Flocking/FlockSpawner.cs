using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockSpawner : MonoBehaviour
{
    bool canSpawn = false;
    [SerializeField] float maxSpawnTimer = 15f;
    [SerializeField] GameObject boidPrefab;
    [SerializeField] List<Transform> spawnPositions;

    // Update is called once per frame
    void Update()
    {
        if (canSpawn) Spawn();
        else StartCoroutine(WaitToSpawn(maxSpawnTimer));

    }

    IEnumerator WaitToSpawn(float _maxSpawnTime)
    {
        yield return new WaitForSeconds(_maxSpawnTime);
        canSpawn = true;
    }

    void Spawn()
    {
        canSpawn = false;
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            Instantiate(boidPrefab, spawnPositions[i]);
        }
    }
}
