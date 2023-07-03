using _Main.Scripts.FSM_SO_VERSION;
using _Main.Scripts.Steering_Behaviours.Steering_Behaviours;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Main.Scripts.Entities.Player
{
    public class PlayerModel : EntityModel
    {

        [SerializeField] private StateData[] fsmStates;
        [SerializeField] private float maxSpeed;
        [SerializeField] public float mana;
        [SerializeField] public float cooldown;
        public float lastSpecialAtk;
        [SerializeField] public int manaCost;
        [SerializeField] private float jumpForce;
        [SerializeField] private float maxLife = 100;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] float groundCheckLength;
        [SerializeField] ProjectileScript projectile;
        [SerializeField] GameObject projectileGO;
        [SerializeField] Transform projectilePosition;
        [SerializeField] Transform punchPosition;
        [SerializeField] GameObject guitarPrefab;
        [SerializeField] private Slider manaSlider;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float sightRange;
        [SerializeField] private LayerMask sightMask;
        public bool targetInSight = false;
        [SerializeField] private float TotalSightDegrees;
        [SerializeField] private LayerMask obsMask;
        private Transform target;
        [SerializeField] private HealthBarScript _healthBar;



        private PlayerView _view;
        PlayerController _controller;
        private HealthController _healthController;
        bool _isGrounded;

        Rigidbody _rigidbody;
        Transform _transform;

        public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
        public PlayerView View { get => _view; set => _view = value; }
        public PlayerController Controller { get => _controller; set => _controller = value; }
        public HealthController HealthController { get => _healthController; set => _healthController = value; }
        public Transform Target { get => target; set => target = value; }

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _view = GetComponent<PlayerView>();
            _controller = GetComponent<PlayerController>();
            _healthController = new HealthController(maxLife);
            _healthController.OnDie += Die;
            if (_healthBar != null) _healthBar.UpdateHealthBar(_healthController.MaxHealth, _healthController.CurrentHealth);
            //meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        public void ManaBar()
        {
            if (manaSlider != null) manaSlider.GetComponent<Slider>().value = mana;
        }

        public void CheckGround()
        {
            _isGrounded = Physics.CheckSphere(transform.position, groundCheckLength, groundMask);
            //View.PlayerGroundedAnimation(_isGrounded);
            //View.PlayerFallingAnimation(!_isGrounded);
        }

        public override void Move(Vector3 direction)
        {
            //_view.PlayRunAnimation(true);
            direction.y = 0;
            _rigidbody.velocity = direction * maxSpeed;
            if (direction.x != 0 || direction.z != 0)
                transform.forward = direction;

        }
        public void Jump()
        {
            _rigidbody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
        public override void LookDir(Vector3 dir)
        {
            if (dir == Vector3.zero) return;
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * rotSpeed);
        }
        public override void GetDamage(int damage)
        {
            //StartCoroutine(FlashRed());
            _healthBar.UpdateHealthBar(_healthController.MaxHealth, _healthController.CurrentHealth);
            _healthController.TakeDamage(damage);

        }

        public override void Heal(int healingPoint)
        {
            _healthController.Heal(healingPoint);
        }

        public void InstantiateFireball()
        {
            GameObject fireball = Instantiate(projectileGO, projectilePosition.transform.position, projectilePosition.transform.rotation) as GameObject;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
        }
        public void EnableGuitar()
        {
            guitarPrefab.SetActive(true);
        }

        public void DisableGuitar()
        {
            guitarPrefab.SetActive(false);
        }
        public override bool IsEntityDead()
        {
            return _healthController.CurrentHealth <= 0;
        }

        public bool LineOfSight()
        {
            target = null;
            Collider[] overlapSphere = Physics.OverlapSphere(transform.position, sightRange, sightMask);

            if (overlapSphere.Length > 0)
            {
                target = overlapSphere[0].transform;
            }

            targetInSight = false;
            if (target != null)
            {
                // 1 - Si está en mi rango de visión
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (distanceToTarget <= sightRange)
                {
                    // 2 - Si está en mi cono de visión
                    Vector3 targetDir = (target.position - transform.position).normalized; // Asi se calcula
                    float angleToTarget = Vector3.Angle(transform.forward, targetDir);
                    if (angleToTarget <= TotalSightDegrees)
                    {
                        RaycastHit hitInfo = new RaycastHit();

                        if (!Physics.Raycast(transform.position, targetDir, out hitInfo, distanceToTarget, obsMask))
                        {
                            targetInSight = true;
                        IsSeeingTarget = true;
                        }
                        else
                        {
                            targetInSight = false;
                            IsSeeingTarget = false;
                        }

                    }

                }
            }
            return targetInSight;
        }

        public override void Die()
        {
            SceneManager.LoadScene("Game Over");
        }

        public override EntityModel GetModel() => this;
        public override StateData[] GetStates() => fsmStates;
        public override Vector3 GetFoward() => transform.forward;
        public override float GetSpeed() => _rigidbody.velocity.magnitude;
        public override Rigidbody GetRigidbody() => _rigidbody;

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(punchPosition.position, sightRange);
        }
    }
}