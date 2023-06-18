using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyController : MonoBehaviour
{
    TestEnemyModel _model;
    void Start()
    {
        _model = GetComponent<TestEnemyModel>();
    }

    void Update()
    {
        if (_model.readyToMove)
        {
            //_model.Run();
        }
    }
}
