using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.BossStates
{
    [CreateAssetMenu(fileName = "Idle State", menuName = "_main/States/Boss States/Idle State", order = 0)]
    public class IdleBossState : State
    {
        BossEnemyModel bossModel;
        public override void EnterState(EntityModel model)
        {
            bossModel = model as BossEnemyModel;
        }

        public override void ExecuteState(EntityModel model)
        {

            Debug.Log("Boss Idle State Execute");
        }

        public override void ExitState(EntityModel model)
        {

        }
    }
}
