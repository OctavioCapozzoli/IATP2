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

        public void PlayerJumpAnimation(bool isJumping)
        {
            _animator.SetBool("isJumping", isJumping);
        }

        public void PlayerGroundedAnimation(bool isGrounded)
        {
            _animator.SetBool("isGrounded", isGrounded);
        }

        public void PlayerFallingAnimation(bool isFalling)
        {
            _animator.SetBool("isFalling", isFalling);
        }

    }
}