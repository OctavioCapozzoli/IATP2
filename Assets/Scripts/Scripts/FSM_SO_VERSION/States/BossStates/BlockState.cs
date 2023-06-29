using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.FSM_SO_VERSION.Conditions.BossConditions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.BossStates
{
    [CreateAssetMenu(fileName = "Block State", menuName = "_main/States/Boss States/Block State", order = 0)]
    public class BlockState : State
    {
        BossEnemyModel bossEnemyModel;
        float timer = 0;

        public override void EnterState(EntityModel model)
        {
            bossEnemyModel = model as BossEnemyModel;
            timer = 0;
        }

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Boss Block State Execute");
            timer += Time.deltaTime;
            if (timer <= bossEnemyModel.GetData().BlockStateTimer)
            {
                bossEnemyModel.GetData().IsInvulnerable = true;
                Debug.Log("Boss is blocking attacks");
                bossEnemyModel.EnemyView.PlayBlockAnimation(true);
            }
            //else
            //{
            //    bossEnemyModel.GetData().IsAttackDone = false;
            //    bossEnemyModel.GetData().IsInvulnerable = false;
            //}
        }
        public override void ExitState(EntityModel model)
        {
            Debug.Log("Salgo del state");
            bossEnemyModel.GetData().IsAttackDone = false;
            bossEnemyModel.GetData().IsInvulnerable = false;
        }
    }
}
