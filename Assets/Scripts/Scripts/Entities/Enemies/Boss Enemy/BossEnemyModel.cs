using _Main.Scripts.Entities.Enemies.Data;
using _Main.Scripts.Entities.Player;
using _Main.Scripts.FSM_SO_VERSION;
using _Main.Scripts.Steering_Behaviours.Steering_Behaviours;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Scripts.Entities.Enemies
{
    public class BossEnemyModel : EntityModel
    {
        [SerializeField] private BossEnemyData data;
        [SerializeField] private float multiplier;
        [SerializeField] private Transform[] patrolPoints;
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private LayerMask obsMask;
        [SerializeField] float obsAvoidanceRadius = 4;
        [SerializeField] int obsAvoidanceMaxObs = 10;
        bool isMoving;
        BossEnemyView _enemyView;
        bool targetInSight = false;
        [SerializeField] bool bossFSMOn = false;
        int boidsCount;

        private Rigidbody _rb;
        private HealthController _healthController;
        [SerializeField] BossEnemyController _controller;
        private ObstacleAvoidance _obstacleAvoidance;

        [SerializeField] private HealthBarScript _healthBar;

        [SerializeField] GameObject flockingBoidPrefab;
        [SerializeField] List<Transform> flockingSpawnPositions;

        public GameObject leftHandBat;
        public GameObject rightHandBat;

        public BossEnemyController Controller { get => _controller; set => _controller = value; }
        public BossEnemyView EnemyView { get => _enemyView; set => _enemyView = value; }
        public bool TargetInSight { get => targetInSight; set => targetInSight = value; }
        public bool IsMoving { get => isMoving; set => isMoving = value; }
        public HealthController HealthController { get => _healthController; set => _healthController = value; }
        public List<Transform> FlockingSpawnPositions { get => flockingSpawnPositions; set => flockingSpawnPositions = value; }
        public GameObject FlockingBoidPrefab { get => flockingBoidPrefab; set => flockingBoidPrefab = value; }
        public int BoidsCount { get => boidsCount; set => boidsCount = value; }

        #region Attack Colliders Activation/Deactivation
        public void TurnOnLeftHandBat()
        {
            leftHandCollider.SetActive(true);
        }
        public void TurnOffLeftHandBat()
        {
            leftHandCollider.SetActive(false);
        }
        public void TurnOnRightHandBat()
        {
            rightHandCollider.SetActive(true);
        }
        public void TurnOffRightHandBat()
        {
            rightHandCollider.SetActive(false);
        }
        #endregion
        private void Awake()
        {

            _rb = GetComponent<Rigidbody>();
            _healthController = new HealthController(data.MaxLife);
            _enemyView = GetComponent<BossEnemyView>();

            _obstacleAvoidance = new ObstacleAvoidance(transform, obsAvoidanceRadius, obsAvoidanceMaxObs, data.TotalSightDegrees, obsMask);

            _healthController.OnDie += Die;

            if (_healthBar != null) _healthBar.UpdateHealthBar(HealthController.MaxHealth, HealthController.CurrentHealth);
        }

        private void Start()
        {
            boidsCount = 0;
            if (GameObject.FindWithTag("Player").GetComponent<PlayerModel>())
            {
                playerModel = GameObject.FindWithTag("Player").GetComponent<PlayerModel>();
                bossFSMOn = data.IsInBossRoom;
            }
        }

        private void Update()
        {
            Debug.Log("boss state health check: " + HealthController.CurrentHealth);
            Debug.Log("Boss state pasa a desperate: " + (HealthController.CurrentHealth <= GetData().SummoningAttackHealthThreshold));
        }

        public override void Die()
        {
            StartCoroutine(WaitToDestroy());
            SceneManager.LoadScene("Win");
            Destroy(gameObject);
        }

        IEnumerator WaitToDestroy()
        {
            _enemyView.PlayDeathAnimation();
            yield return new WaitForSeconds(1.5f);
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
            _enemyView.PlayWalkAnimation(true);
        }

        public override void LookDir(Vector3 dir)
        {
            if (dir == Vector3.zero) return;
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * rotSpeed);
        }

        public override void GetDamage(int damage)
        {
            _healthBar.UpdateHealthBar(HealthController.MaxHealth, HealthController.CurrentHealth);
            _healthController.TakeDamage(damage);
        }

        public override void Heal(int healingPoint)
        {
            _healthController.Heal(healingPoint);
        }

        public override Rigidbody GetRigidbody() => _rb;

        public override EntityModel GetModel() => this;

        public void SetBlockConditions()
        {
            IsBlocking = true; //TODO testear si pasa bien al estado. De no ser as� pasar normalmente desde idle y tratarlo como otro ataque aparte
        }
        public override bool IsEntityDead()
        {
            return _healthController.CurrentHealth <= 0;
        }

        public bool LineOfSight(Transform target)
        {
            target = null;
            Collider[] overlapSphere = Physics.OverlapSphere(transform.position, data.SightRange, data.TargetLayer);

            if (overlapSphere.Length > 0)
            {
                target = overlapSphere[0].transform;
            }

            targetInSight = false;
            if (target != null)
            {
                // 1 - Si est� en mi rango de visi�n
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (distanceToTarget <= data.SightRange)
                {
                    // 2 - Si est� en mi cono de visi�n
                    Vector3 targetDir = (target.position - transform.position).normalized; // Asi se calcula
                    float angleToTarget = Vector3.Angle(transform.forward, targetDir);

                    if (angleToTarget <= data.TotalSightDegrees)
                    {
                        RaycastHit hitInfo = new RaycastHit();

                        if (!Physics.Raycast(transform.position, targetDir, out hitInfo, distanceToTarget, obsMask))
                        {
                            targetInSight = true;
                        }

                    }
                    if (targetInSight)
                    {
                        IsAllert = true;
                        IsSeeingTarget = true;
                    }
                    else
                    {
                        IsAllert = false;
                        IsSeeingTarget = false;
                    }

                }
            }
            return targetInSight;
        }

        public PlayerModel GetTarget() => playerModel;
        public BossEnemyData GetData() => data;
        public override StateData[] GetStates() => data.FsmStates;
        public Transform[] GetPatrolPoints() => patrolPoints;

        private Vector3 _lastViewDir;

        public void SetLastViewDir(Vector3 dir) => _lastViewDir = dir;
        public Vector3 GetLastViewDir() => _lastViewDir;

        public override Vector3 GetFoward() => transform.forward;


        public override float GetSpeed() => _rb.velocity.magnitude;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, data.SightRange);

            Gizmos.color = Color.blue;
            Vector3 rightLimit = Quaternion.AngleAxis(data.TotalSightDegrees, Vector3.up) * Vector3.forward;
            Gizmos.DrawLine(transform.position, transform.position + (rightLimit * data.SightRange));

            Vector3 leftLimit = Quaternion.AngleAxis(data.TotalSightDegrees, Vector3.up) * Vector3.forward;
            Gizmos.DrawLine(transform.position, transform.position + (leftLimit * data.SightRange));
        }
    }
}