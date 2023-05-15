using _Main.Scripts.FSM_SO_VERSION;
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
        bool isJumping;
        bool isDead;
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
        public bool IsJumping { get => isJumping; set => isJumping = value; }
        #endregion

        public float rotSpeed;

        public abstract void Move(Vector3 direction);
        public abstract void LookDir(Vector3 direction);

        public virtual void DoDamage(EntityModel affectedModel) { }

        public abstract void GetDamage(int damage);
        public abstract void Heal(int healingPoint);
        public abstract Rigidbody GetRigidbody();
        public abstract EntityModel GetModel();
        public abstract StateData[] GetStates();
        public abstract bool IsDead();
        public abstract void Die();
        public abstract Vector3 GetFoward();
        public abstract float GetSpeed();
    }
}