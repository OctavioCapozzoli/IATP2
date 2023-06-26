using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "Special Attack State", menuName = "_main/States/Player States/Special Attack State", order = 0)]

    public class SpecialAttackStatePlayer : State
    {

        PlayerModel playerModel;

        public override void EnterState(EntityModel model)
        {
            playerModel = model as PlayerModel;
            if (playerModel.mana >= playerModel.manaCost)
            {
                if (Time.time - playerModel.lastSpecialAtk < playerModel.cooldown)
                {
                    return;
                }
                playerModel.lastSpecialAtk = Time.time;
                playerModel.mana -= playerModel.manaCost;
                playerModel.Controller.PlayerSpecialAttacksRouletteWheel.RouletteAction();
            }
        }

        public override void ExecuteState(EntityModel model)
        {

        }
        public override void ExitState(EntityModel model)
        {

        }

    }
}
