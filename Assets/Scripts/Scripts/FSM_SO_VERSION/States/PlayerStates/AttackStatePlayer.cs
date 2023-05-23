using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{

    [CreateAssetMenu(fileName = "RegularAttackState", menuName = "_main/States/PlayerStates/RegularAttackState", order = 0)]

    public class AttackStatePlayer : State
    {

        PlayerAttackComboManager comboMgr;

        public override void EnterState(EntityModel model)
        {
            PlayerModel playerModel = model as PlayerModel;
            comboMgr = new PlayerAttackComboManager(playerModel.View, 3f);

        }

        public override void ExecuteState(EntityModel model)
        {
            //if (Input.GetKeyDown(KeyCode.J))
            //{
                comboMgr.IsEnabled = true;
                comboMgr.UpdateCombo();
            //}
            //else comboMgr.IsEnabled = false;
        }
        public override void ExitState(EntityModel model)
        {

        }
    }
}