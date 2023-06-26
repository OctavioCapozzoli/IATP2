using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "Death State", menuName = "_main/States/Player States/Death State", order = 0)]

    public class PlayerDeathState : State
    {
        public override void EnterState(EntityModel model)
        {
            PlayerModel playerModel = model as PlayerModel;
            playerModel.Die();
        }
        public override void ExecuteState(EntityModel model)
        {
            // Cambio color player
        }

        public override void ExitState(EntityModel model)
        {

        }
    }
}
