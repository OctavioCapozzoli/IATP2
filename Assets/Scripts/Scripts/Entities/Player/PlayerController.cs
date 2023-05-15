using _Main.Scripts.FSM_SO_VERSION;
using UnityEngine;

namespace _Main.Scripts.Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] StateData initialState;
        
        private FsmScript _playerFsm;
        private StateData _currentState;
        private PlayerModel _model;

        private void Awake()
        {
            _model = GetComponent<PlayerModel>();
        }
        private void Start()
        {
            _playerFsm = new FsmScript(_model, initialState);
        }
        private void Update()
        {
            _model.CheckGround();
            _playerFsm.UpdateState();

            if (_model.IsGrounded)
            {
                CheckMovementControls();
                CheckJumpControls();
            }
        }
        void CheckMovementControls()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                _model.isWalking = true;
                _model.isIdle = false;
                _model.isJumping = false;
            }
            else
            {
                _model.isWalking = false;
                _model.isIdle = true;
                _model.isJumping = false;
            }
        }
        void CheckJumpControls()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _model.isJumping = true;
                _model.isIdle = false;
                _model.isWalking = false;
            }
        }
    }
}