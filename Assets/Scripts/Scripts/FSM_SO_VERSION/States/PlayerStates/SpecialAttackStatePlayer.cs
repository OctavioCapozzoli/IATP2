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

        PlayerModel playerModel;

        public override void EnterState(EntityModel model)
        {
            playerModel = model as PlayerModel;
            playerModel.Controller.PlayerSpecialAttacksRouletteWheel.RouletteAction();
        }

        public override void ExecuteState(EntityModel model)
        {

        }
        public override void ExitState(EntityModel model)
        {

        }

    }
}
