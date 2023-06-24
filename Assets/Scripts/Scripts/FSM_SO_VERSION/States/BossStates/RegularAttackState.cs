using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Roulette_Wheel;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.BossStates
{
    [CreateAssetMenu(fileName = "Regular Attack State", menuName = "_main/States/Boss States/Regular Attack State", order = 0)]
    public class RegularAttackState : State
    {

        BossEnemyModel bossModel;
        float timer = 0, rouletteMaxCooldown = 1.5f, rouletteCooldownTimer = 0;
        public override void EnterState(EntityModel model)
        {
            bossModel = model as BossEnemyModel;

            bossModel.EnemyView.PlayWalkAnimation(false);
            bossModel.GetRigidbody().velocity = Vector3.zero;

        }

        public override void ExecuteState(EntityModel model)
        {
            timer += Time.deltaTime;
            if (timer <= bossModel.GetData().AttackStateTimer)
            {
                bossModel.Controller.BossEnemyRoulette.EnemyRegularAttacksRouletteAction();
                rouletteCooldownTimer += Time.deltaTime;
                if (rouletteCooldownTimer >= rouletteMaxCooldown) timer = 0;

            }
            //else bossModel.GetData().RegularAttackHealthThreshold = false;
        }

        public override void ExitState(EntityModel model)
        {

        }
    }
}