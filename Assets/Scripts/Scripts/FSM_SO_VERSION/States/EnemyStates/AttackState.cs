using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Entities.Enemies.Data;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.EnemyStates
{
    [CreateAssetMenu(fileName = "AttackState", menuName = "_main/States/Enemy States/Attack State", order = 0)]
    public class AttackState : State
    {
        private class AttackData
        {
            public EnemyModel EnemyModel;
            public EnemyData Data;
            public int TargetLayer;
        }

        float attackCooldown;
        private Dictionary<EntityModel, EnemyModel> _entitiesData = new Dictionary<EntityModel, EnemyModel>();
        public override void EnterState(EntityModel model)
        {
            _entitiesData.Add(model, model as EnemyModel);
            _entitiesData[model].EnemyView.PlayWalkAnimation(false);
            _entitiesData[model].GetRigidbody().velocity = Vector3.zero;
            _entitiesData[model].Controller.EnemyRoulette.EnemyAttackOrBlockRouletteAction();
            attackCooldown = .5f;
        }

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Enemy attack state execute");
            //attackCooldown -= Time.deltaTime;
        }

        public override void ExitState(EntityModel model)
        {
            attackCooldown = .5f;
            _entitiesData.Remove(model);
        }


    }
}