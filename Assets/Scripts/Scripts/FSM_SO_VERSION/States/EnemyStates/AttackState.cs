using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Entities.Enemies.Data;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.EnemyStates
{
    [CreateAssetMenu(fileName = "AttackState", menuName = "_main/States/EnemyStates/AttackState", order = 0)]
    public class AttackState : State
    {
        private class AttackData
        {
            public EnemyModel EnemyModel;
            public EnemyData Data;
            public int TargetLayer;
        }

        private Dictionary<EntityModel, EnemyModel> _entitiesData = new Dictionary<EntityModel, EnemyModel>();

        public override void EnterState(EntityModel model)
        {
            _entitiesData.Add(model, model as EnemyModel);

            _entitiesData[model].Controller.EnemyRoulette.EnemyAttackOrBlockRouletteAction();
            model.IsAttacking = true;

        }

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Attack state execute");
        }

        public override void ExitState(EntityModel model)
        {
            _entitiesData.Remove(model);

            model.IsAttacking = false;
        }


    }
}