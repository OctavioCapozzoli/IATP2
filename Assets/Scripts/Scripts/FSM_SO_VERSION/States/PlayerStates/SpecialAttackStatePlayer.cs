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
            //En este estado debe activarse una ruleta en el awake,
            //para decidir el tipo de ataque especial que se va a utilizar
            //(A mayor daño menor probabilidad de salir)
            playerModel.View.PlayerSpecialAttack1();
        }

        public override void ExecuteState(EntityModel model)
        {
            if (Input.GetKeyDown(KeyCode.J) && playerModel.IsIdle)
            {

            }
        }
        public override void ExitState(EntityModel model)
        {

        }

    }
}
