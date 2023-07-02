using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.FSM_SO_VERSION.Conditions.BossConditions;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.BossStates
{
    [CreateAssetMenu(fileName = "Desperate Atack State", menuName = "_main/States/Boss States/Desperate Atack State", order = 0)]
    public class DesperateAttackState : State
    {
        BossEnemyModel bossModel;
        float timer = 0f, attackCooldownTimer = 0f, attackMaxCooldownTimer = .5f;
        public override void EnterState(EntityModel model)
        {
            bossModel = model as BossEnemyModel;
            timer = 0;
        }
        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Boss Desperate State Execute");
            if (!bossModel.GetData().IsAttackDone)
            {
                timer += Time.deltaTime;
                if (timer <= bossModel.GetData().AttackStateTimer)
                {
                    bossModel.Controller.BossEnemyRoulette.EnemyDesperateAttacksRouletteAction();
                    attackCooldownTimer += Time.deltaTime;
                    if (attackCooldownTimer >= attackMaxCooldownTimer) attackCooldownTimer = 0;
                }
                else bossModel.GetData().IsAttackDone = true;
            }
        }

        public override void ExitState(EntityModel model)
        {
        }
    }
}
