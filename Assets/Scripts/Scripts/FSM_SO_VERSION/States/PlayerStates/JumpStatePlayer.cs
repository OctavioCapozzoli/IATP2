using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using System;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "JumpState", menuName = "_main/States/PlayerStates/JumpState", order = 0)]
    public class JumpStatePlayer : State
    {
        private PlayerModel _playerModel;
        public override void EnterState(EntityModel model)
        {
            _playerModel = model as PlayerModel;
            _playerModel.View.PlayerJumpAnimation(true);
            _playerModel.Jump();
        }

        public override void ExecuteState(EntityModel model)
        {
        }
        public override void ExitState(EntityModel model)
        {
            _playerModel.View.PlayerJumpAnimation(false);
        }
    }
}
