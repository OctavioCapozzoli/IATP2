using UnityEngine;

namespace _Main.Scripts.Entities.Enemies
{
    public class EnemyView : MonoBehaviour
    {
        private Animator _animator;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayWalkAnimation(bool _value)
        {
            _animator.SetBool("isWalking", _value);
        }
        public void PlayAttack1Animation()
        {
            Debug.Log("Enemy attack animation 1");
            _animator.SetTrigger("onAttack1");
        }
        public void PlayAttack2Animation()
        {
            Debug.Log("Enemy attack animation 2");
            _animator.SetTrigger("onAttack2");
        }
        public void PlayAttack3Animation()
        {
            Debug.Log("Enemy attack animation 3");
            _animator.SetTrigger("onAttack3");
        }
        public void PlayDamageAnimation()
        {
            _animator.SetTrigger("onDamage");
        }
        public void PlayDeathAnimation()
        {
            _animator.SetTrigger("onDeath");
        }
    }
}