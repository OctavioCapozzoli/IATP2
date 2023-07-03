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
        float timer = 0, rouletteMaxCooldown = 1.5f, rouletteCooldownTimer = 0;
        public override void EnterState(EntityModel model)
        {
            bossModel = model as BossEnemyModel;
            bossModel.EnemyView.PlayWalkAnimation(false);
            bossModel.GetRigidbody().velocity = Vector3.zero;
            bossModel.GetData().IsInvulnerable = false;
        }
        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Boss State Desperate Execute");
                timer += Time.deltaTime;
                if (timer <= bossModel.GetData().AttackStateTimer && !bossModel.GetData().IsAttackDone)
                {
                    rouletteCooldownTimer += Time.deltaTime;
                if (rouletteCooldownTimer >= rouletteMaxCooldown)
                {
                    bossModel.Controller.BossEnemyRoulette.EnemyDesperateAttacksRouletteAction();
                    rouletteCooldownTimer = 0;
                
                }
                else
                {
                    timer = 0;
                    bossModel.GetData().IsAttackDone = true;
                }
            }
        }

        public override void ExitState(EntityModel model)
        {
        }
    }
}
