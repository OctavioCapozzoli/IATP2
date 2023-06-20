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

        public void PlayWalkAnimation(float velocity)
        {
            _animator.SetFloat("Vel", velocity);
        }
        public void PlayRunAnimation(bool _value)
        {
            _animator.SetBool("isSeeking", _value);
        }
        public void PlayAttack1Animation()
        {
            _animator.SetTrigger("onAttack1");
        }
        public void PlayAttack2Animation()
        {
            _animator.SetTrigger("onAttack2");
        }
        public void PlayAttack3Animation()
        {
            _animator.SetTrigger("onAttack3");
        }
        public void PlayBlockAnimation()
        {
            _animator.SetTrigger("onBlock");
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