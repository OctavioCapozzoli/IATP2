using _Main.Scripts.FSM_SO_VERSION;
using UnityEngine;

namespace _Main.Scripts.Entities
{
    public abstract class EntityModel : MonoBehaviour
    {

        public bool isIdle;
        public bool isPatrolling;
        public bool isSeeingTarget;
        public bool isChasing;
        public bool isAttacking;
        public bool isSearching;
        public bool isAllert;

        public bool isWalking;
        public bool isJumping;
        public bool isDead;

        public Rigidbody _Rb { get; set; }

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