using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace _Main.Scripts.Entities.Enemies
{
    public class BossEnemyView : MonoBehaviour
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

        #region Regular Attacks 
        public void PlayAttack1Animation()
        {
            _animator.SetTrigger("onEnhancedAttack1");
        }
        public void PlayAttack2Animation()
        {
            _animator.SetTrigger("onEnhancedAttack2");
        }
        public void PlayAttack3Animation()
        {
            _animator.SetTrigger("onEnhancedAttack3");
        }
        #endregion

        #region Enhanced Attacks
        public void PlayEnhancedAttack1Animation()
        {
            _animator.SetTrigger("onAttack1");
        }
        public void PlayEnhancedAttack2Animation()
        {
            _animator.SetTrigger("onAttack2");
        }
        public void PlayEnhancedAttack3Animation()
        {
            _animator.SetTrigger("onAttack3");
        }
        #endregion

        #region Desperate Attacks
        public void PlayDesperateAttack1Animation()
        {
            _animator.SetTrigger("onDesperateAttack1");
        }
        public void PlayDesperateAttack2Animation()
        {
            _animator.SetTrigger("onDesperateAttack2");
        }
        public void PlayDesperateAttack3Animation()
        {
            _animator.SetTrigger("onDesperateAttack3");
        }
        #endregion

        public void PlayBlockAnimation(bool _value)
        {
            _animator.SetBool("isBlocking", _value);
        }
        public void PlayDeathAnimation()
        {
            _animator.SetTrigger("onDeath");
        }
    }
}
