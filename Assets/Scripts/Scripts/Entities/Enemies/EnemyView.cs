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

        public void PlayRunAnimation(float velocity)
        {
            //_animator.SetFloat("Vel", velocity);
        }
        public void PlayDamageAnimation()
        {
            _animator.SetTrigger("onDamage");
        }
        public void PlayBlockAnimation()
        {
            _animator.SetTrigger("onBlock");
        }
    }
}