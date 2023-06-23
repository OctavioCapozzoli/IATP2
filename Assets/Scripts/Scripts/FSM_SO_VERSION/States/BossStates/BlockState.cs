using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.BossStates
{
    [CreateAssetMenu(fileName = "BlockState", menuName = "_main/States/Boss States/Block State", order = 0)]
    public class BlockState : State
    {
        BossEnemyModel bossEnemyModel;
        float timer = 0;

        public override void EnterState(EntityModel model)
        {
        }

        public override void ExecuteState(EntityModel model)
        {
            timer += Time.deltaTime;
            if (timer <= bossEnemyModel.GetData().BlockStateTimer)
            {
                Debug.Log("Boss is blocking attacks");
                bossEnemyModel.EnemyView.PlayBlockAnimation(true);
            }
            else bossEnemyModel.IsBlocking = false;
        }
        public override void ExitState(EntityModel model)
        {
            timer = 0;
        }
    }
}
