using _Main.Scripts.Entities.Enemies.Data;
using _Main.Scripts.Entities.Player;
using _Main.Scripts.FSM_SO_VERSION;
using _Main.Scripts.Steering_Behaviours.Steering_Behaviours;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.Entities.Enemies
{
    public class EnemyModel : EntityModel
    {
        [SerializeField] private EnemyData data;
        [SerializeField] private float multiplier;
        [SerializeField] private Transform[] patrolPoints;
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private LayerMask obsMask;
        EnemyView _enemyView;


        private Rigidbody _rb;
        private HealthController _healthController;
        private EnemyController _controller;
        private ObstacleAvoidance _obstacleAvoidance;

        public EnemyController Controller { get => _controller; set => _controller = value; }
        public EnemyView EnemyView { get => _enemyView; set => _enemyView = value; }

        public GameObject exclamationSing;
        public GameObject questionSing;

        public float cooldownAttack;
        private void Awake()
        {

            _rb = GetComponent<Rigidbody>();
            _healthController = new HealthController(data.MaxLife);
            _enemyView = GetComponent<EnemyView>();

            _controller = GetComponent<EnemyController>();
            _obstacleAvoidance = new ObstacleAvoidance(transform, 4, 10, data.TotalSightDegrees, obsMask);
            exclamationSing.SetActive(false);
            questionSing.SetActive(false);
            cooldownAttack = 0;

            _healthController.OnDie += Die;
        }

        public void SetWayPoints(List<Node> _waypoints)
        {

            var list = new List<Vector3>();
            for (int i = 0; i < _waypoints.Count; i++)
            {
                list.Add(_waypoints[i].worldPosition);
            }
            //SetWayPoints(list);
        }

        public override void Move(Vector3 direction)
        {
            direction.y = 0;
            direction += _obstacleAvoidance.GetDir() * multiplier;
            _rb.velocity = direction.normalized * (data.MovementSpeed * Time.deltaTime);

            transform.forward = Vector3.Lerp(transform.forward, direction, rotSpeed * Time.deltaTime);
            _enemyView.PlayRunAnimation(_rb.velocity.magnitude);
        }

        public override void LookDir(Vector3 dir)
        {
            if (dir == Vector3.zero) return;
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * rotSpeed);
        }

        public override void GetDamage(int damage)
        {
            _healthController.TakeDamage(damage);
        }

        public override void Heal(int healingPoint)
        {
            _healthController.Heal(healingPoint);
        }

        public override Rigidbody GetRigidbody() => _rb;

        public override EntityModel GetModel() => this;

        public override bool IsEntityDead()
        {
            return _healthController.CurrentHealth <= 0;
        }

        public override void Die()
        {
            Destroy(gameObject);
        }

        public bool LineOfSight(Transform target)
        {
            Vector3 diff = target.transform.position + Vector3.up - (transform.position + Vector3.up);

            float distanceToTarget = diff.magnitude;
            if (distanceToTarget > data.SightRange) return false;

            float angleToTarget = Vector3.Angle(transform.position, diff.normalized);

            if (angleToTarget > data.TotalSightDegrees) return false;

            if (Physics.Raycast(transform.position + Vector3.up, diff.normalized, data.SightRange, data.TargetLayer))
            {
                IsAllert = true;
                IsSeeingTarget = true;
                return true;
            }
            else
            {

                IsAllert = false;
                IsSeeingTarget = false;

                return false;
            }
        }

        public PlayerModel GetTarget() => playerModel;
        public EnemyData GetData() => data;
        public override StateData[] GetStates() => data.FsmStates;
        public Transform[] GetPatrolPoints() => patrolPoints;

        private Vector3 _lastViewDir;

        public void SetLastViewDir(Vector3 dir) => _lastViewDir = dir;
        public Vector3 GetLastViewDir() => _lastViewDir;

        public override Vector3 GetFoward() => transform.forward;


        public override float GetSpeed() => _rb.velocity.magnitude;


    }
}