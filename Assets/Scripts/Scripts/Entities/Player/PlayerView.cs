using UnityEngine;

namespace _Main.Scripts.Entities.Player
{
    public class PlayerView : MonoBehaviour
    {
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayRunAnimation(bool isMoving)
        {
            _animator.SetBool("isMoving", isMoving);
        }

        #region Regular Attacks (Combo)
        public void PlayerComboAttack1()
        {
            _animator.SetTrigger("onRegularAttack");
        }
        public void PlayerComboAttack2()
        {
            _animator.SetTrigger("onRegAttackAnim2");
        }
        public void PlayerComboAttack3()
        {
            _animator.SetTrigger("onRegAttackAnim3");
        }
        #endregion

        #region Special Attacks
        public void PlayerSpecialAttack1()
        {
            _animator.SetTrigger("PlayerSpecialAttack1");
        }
        public void PlayerSpecialAttack2()
        {
            _animator.SetTrigger("PlayerSpecialAttack2");
        }
        public void PlayerSpecialAttack3()
        {
            _animator.SetTrigger("PlayerSpecialAttack3");
        }
        #endregion
    }
}