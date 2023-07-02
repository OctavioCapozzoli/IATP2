using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies.Data;
using _Main.Scripts.Entities.Player;
using _Main.Scripts.FSM_SO_VERSION;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : EntityModel, IBoid
{
    [SerializeField] private EnemyData data;
    [SerializeField] private int damage;
    public float radius;
    public float speed;
    Rigidbody _rb;
    private HealthController _healthController;
    [SerializeField] private GameObject explosionVFX;
    public Vector3 Position => transform.position;

    public Vector3 Front => transform.forward;

    public float Radius => radius;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _healthController = new HealthController(data.MaxLife);

        _healthController.OnDie += Die;
    }

    public override void Move(Vector3 dir)
    {
        dir *= speed;
        dir.y = _rb.velocity.y;
        _rb.velocity = dir;
    }

    public override void LookDir(Vector3 dir)
    {
        dir.y = 0;
        transform.forward = dir;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Position, radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerModel>().HealthController.TakeDamage(damage);
            Debug.Log("Player was damaged, current health is: " + other.gameObject.GetComponent<PlayerModel>().HealthController.CurrentHealth);
            other.gameObject.GetComponent<EntityModel>().IsDamaged = true;
            Instantiate(explosionVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

    public override void GetDamage(int damage)
    {
        throw new System.NotImplementedException();
    }

    public override void Heal(int healingPoint)
    {
        throw new System.NotImplementedException();
    }

    public override Rigidbody GetRigidbody() => _rb;

    public override EntityModel GetModel() => this;

    public override StateData[] GetStates() => data.FsmStates;

    public override bool IsEntityDead()
    {
        return _healthController.CurrentHealth <= 0;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override Vector3 GetFoward() => transform.forward;

    public override float GetSpeed() => _rb.velocity.magnitude;
}
