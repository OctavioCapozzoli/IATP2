using _Main.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "Damage State", menuName = "_main/States/Player States/Damage State", order = 0)]

    public class PlayerDamageState : State
    {
        public override void EnterState(EntityModel model)
        {

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
