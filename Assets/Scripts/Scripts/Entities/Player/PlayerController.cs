using _Main.Scripts.FSM_SO_VERSION;
using _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel;
using UnityEngine;

namespace _Main.Scripts.Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] StateData initialState;

        private FsmScript _playerFsm;
        private StateData _currentState;
        private PlayerModel _model;
        PlayerRouletteWheel _playerSpecialAttacksRouletteWheel;

        public PlayerRouletteWheel PlayerSpecialAttacksRouletteWheel { get => _playerSpecialAttacksRouletteWheel; set => _playerSpecialAttacksRouletteWheel = value; }

        private void Awake()
        {
            _model = GetComponent<PlayerModel>();
        }
        private void Start()
        {
            _playerFsm = new FsmScript(_model, initialState);
            _playerSpecialAttacksRouletteWheel = new PlayerRouletteWheel(_model);
        }
        private void Update()
        {
            _model.CheckGround();
            _playerFsm.UpdateState();

            if (_model.IsGrounded)
            {
                CheckMovementControls();
                CheckJumpControls();
                CheckRegularAttackInput();
                CheckSpecialAttackInput();
            }
        }
        void CheckMovementControls()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                _model.IsWalking = true;
                _model.IsIdle = false;
            }
            else
            {
                _model.IsWalking = false;
                _model.IsIdle = true;
            }
        }
        void CheckJumpControls()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _model.IsIdle = false;
                _model.IsWalking = false;
            }
        }

        void CheckRegularAttackInput()
        {
            if (Input.GetKeyDown(KeyCode.J) && _model.IsIdle)
            {
                _model.IsAttacking = true;
            }
            else
            {
                _model.IsAttacking = false;
            }
        }

        void CheckSpecialAttackInput()
        {
            if (Input.GetKeyDown(KeyCode.Q)) //TODO luego se puede agregar la condición
                                             // de mana suficiente para ejecutar el ataque especial
            {
                _model.IsSpecialAttacking = true;
            }
            else _model.IsSpecialAttacking = false;
        }
    }
}