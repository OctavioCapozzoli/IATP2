using _Main.Scripts.FSM_SO_VERSION;
using System.Collections;
using UnityEngine;

namespace _Main.Scripts.Entities
{
    public abstract class EntityModel : MonoBehaviour
    {

        #region FSM variables
        bool isIdle;
        bool isPatrolling;
        bool isSeeingTarget;
        bool isChasing;
        bool isAttacking;
        bool isSearching;
        bool isAllert;

        bool isWalking;
        bool isDamaged;
        bool isFleeing;
        bool isBlocking;
        bool isDead;
        bool isSpecialAttacking;
        #endregion

        public Rigidbody _Rb { get; set; }

        #region Encapsulated FSM variables
        public bool IsIdle { get => isIdle; set => isIdle = value; }
        public bool IsPatrolling { get => isPatrolling; set => isPatrolling = value; }
        public bool IsSeeingTarget { get => isSeeingTarget; set => isSeeingTarget = value; }
        public bool IsChasing { get => isChasing; set => isChasing = value; }
        public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
        public bool IsSearching { get => isSearching; set => isSearching = value; }
        public bool IsAllert { get => isAllert; set => isAllert = value; }
        public bool IsWalking { get => isWalking; set => isWalking = value; }
        public bool IsDead { get => isDead; set => isDead = value; }
        public bool IsSpecialAttacking { get => isSpecialAttacking; set => isSpecialAttacking = value; }
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        public bool IsFleeing { get => isFleeing; set => isFleeing = value; }
        public bool IsBlocking { get => isBlocking; set => isBlocking = value; }
        #endregion

        public float rotSpeed;

        public GameObject leftHandCollider;
        public GameObject rightHandCollider;
        public GameObject leftFootCollider;
        public GameObject rightFootCollider;

        [SerializeField] private Material redMaterial;
        [SerializeField] private Material material;
        [SerializeField] private SkinnedMeshRenderer meshRenderer;


        #region Attack Colliders Activation/Deactivation
        public virtual void TurnOnLeftHandCollider()
        {
            leftHandCollider.SetActive(true);
        }
        public virtual void TurnOffLeftHandCollider()
        {
            leftHandCollider.SetActive(false);
        }
        public virtual void TurnOnRightHandCollider()
        {
            rightHandCollider.SetActive(true);
        }
        public virtual void TurnOffRightHandCollider()
        {
            rightHandCollider.SetActive(false);
        }
        public virtual void TurnOnLeftFootCollider()
        {
            leftFootCollider.SetActive(true);
        }
        public virtual void TurnOffLeftFootCollider()
        {
            leftFootCollider.SetActive(false);
        }
        public virtual void TurnOnRightFootCollider()
        {
            rightFootCollider.SetActive(true);
        }
        public virtual void TurnOffRightFootCollider()
        {
            rightFootCollider.SetActive(false);
        }
        #endregion
        public abstract void Move(Vector3 direction);
        public abstract void LookDir(Vector3 direction);

        public virtual void DoDamage(EntityModel affectedModel) { }

        public abstract void GetDamage(int damage);
        public abstract void Heal(int healingPoint);
        public abstract Rigidbody GetRigidbody();
        public abstract EntityModel GetModel();
        public abstract StateData[] GetStates();
        public abstract bool IsEntityDead();
        public abstract void Die();
        public abstract Vector3 GetFoward();
        public abstract float GetSpeed();

        public void StartingRutine()
        {
            StartCoroutine(DamageFlash());
        }

        public IEnumerator DamageFlash()
        {
            if(meshRenderer != null)
            {
                meshRenderer.material = redMaterial;
                yield return new WaitForSeconds(0.1f);
                meshRenderer.material = material;
            }
            else
            {
                Debug.Log("mesh renderer null");
            }
            
        }
    }
}