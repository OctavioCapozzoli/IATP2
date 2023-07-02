
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
            bossModel.EnemyView.PlayBlockAnimation(false);
            bossModel.GetRigidbody().velocity = Vector3.zero;
            bossModel.GetData().IsInvulnerable = false;

        }

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Boss Regular Attack State Execute");
            timer += Time.deltaTime;
            if (timer <= bossModel.GetData().AttackStateTimer && !bossModel.GetData().IsAttackDone)
            {
                Debug.Log("Timer boss regular attack is " + timer);
                //rouletteCooldownTimer += Time.deltaTime;
                //bossModel.Controller.BossEnemyRoulette.EnemyRegularAttacksRouletteAction();
                //if (rouletteCooldownTimer >= rouletteMaxCooldown)
                //{

                //    timer = 0;
                //     bossModel.GetData().IsAttackDone = true;
                //}

            }
            else
            {
                timer = 0;
                bossModel.GetData().IsAttackDone = true;
            }
        }

        public override void ExitState(EntityModel model)
        {
            //bossModel.EnemyView.PlayBlockAnimation(false);
        }
    }
}
