using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "SpecialAttackState", menuName = "_main/States/PlayerStates/SpecialAttackState", order = 0)]

    public class SpecialAttackStatePlayer : State
    {
        public override void EnterState(EntityModel model)
        {
            PlayerModel playerModel = model as PlayerModel;
            playerModel.View.PlayerSpecialAttackAnimation();
        }

        public override void ExecuteState(EntityModel model)
        {

        }
        public override void ExitState(EntityModel model)
        {

        }

    }
}
