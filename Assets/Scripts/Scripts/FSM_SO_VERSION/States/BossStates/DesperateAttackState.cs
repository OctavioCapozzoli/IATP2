using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.BossStates
{
    [CreateAssetMenu(fileName = "Summoning Atack State", menuName = "_main/States/Boss States/Summoning Atack State", order = 0)]
    public class DesperateAttackState : State
    {
        BossEnemyModel bossModel;
        public override void EnterState(EntityModel model)
        {
            bossModel = model as BossEnemyModel;
        }
        public override void ExecuteState(EntityModel model)
        {

        }

        public override void ExitState(EntityModel model)
        {

        }
    }
}
