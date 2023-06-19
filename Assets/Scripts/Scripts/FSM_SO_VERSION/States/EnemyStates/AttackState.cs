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

        private Dictionary<EntityModel, AttackData> _allAttackDatas = new Dictionary<EntityModel, AttackData>();
        public override void EnterState(EntityModel model)
        {
            _allAttackDatas.Add(model, new AttackData());

            _allAttackDatas[model].EnemyModel = (EnemyModel)model;
            _allAttackDatas[model].Data = _allAttackDatas[model].EnemyModel.GetData();
            _allAttackDatas[model].TargetLayer = _allAttackDatas[model].EnemyModel.GetTarget().gameObject.layer;


            model.IsAttacking = true;

        }

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Attack state execute");
            var dir = (_allAttackDatas[model].EnemyModel.GetTarget().transform.position - model.transform.position).normalized;

            if (Physics.Raycast(model.transform.position, dir,
                    _allAttackDatas[model].Data.DistanceToAttack, _allAttackDatas[model].TargetLayer))
            {
                _allAttackDatas[model].EnemyModel.GetTarget().GetDamage(10);
            }
        }

        public override void ExitState(EntityModel model)
        {
            _allAttackDatas[model].EnemyModel.cooldownAttack = _allAttackDatas[model].Data.CooldownToAttack;
            _allAttackDatas.Remove(model);



            model.IsAttacking = false;
        }


    }
}