using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.BossStates
{
    [CreateAssetMenu(fileName = "Summoning Atack State", menuName = "_main/States/Boss States/Summoning Atack State", order = 0)]
    public class SummoningAttackState : State
    {
        BossEnemyModel bossModel;
        public override void EnterState(EntityModel model)
        {
            bossModel = model as BossEnemyModel;
            bossModel.EnemyView.PlayWalkAnimation(false);
            bossModel.GetRigidbody().velocity = Vector3.zero;
            for (int i = 0; i < bossModel.FlockingSpawnPositions.Count; i++)
            {
                Instantiate(bossModel.FlockingBoidPrefab, bossModel.FlockingSpawnPositions[i]);
            }

        }

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Boss Summon State Execute");
                bossModel.GetData().CanSummon = false;
        }

        public override void ExitState(EntityModel model)
        {
            bossModel.GetData().CanSummon = true;
        }
    }
}