using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : MonoBehaviour, IBoid
{
    public float radius;
    public float speed;
    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public Vector3 Position => transform.position;

    public Vector3 Front => transform.forward;

    public float Radius => radius;

    public void Move(Vector3 dir)
    {
        dir *= speed;
        dir.y = _rb.velocity.y;
        _rb.velocity = dir;
    }

    public void LookDir(Vector3 dir)
    {
        dir.y = 0;
        transform.forward = dir;
    }
}
