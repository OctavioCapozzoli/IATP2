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

        public void FireballSpecialAttack()
        {
            Debug.Log("Player Special Attack 1");
            _animator.SetTrigger("onSpecialAttack1");
        }
        public void GuitarSmashSpecialAttack()
        {
            Debug.Log("Player Special Attack 2");
            _animator.SetTrigger("onSpecialAttack2");
        }
        public void FirePunchesSpecialAttack()
        {
            Debug.Log("Player Special Attack 3");
            _animator.SetTrigger("onSpecialAttack3");
        }
        #endregion
    }
}