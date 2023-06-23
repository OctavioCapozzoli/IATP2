﻿using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.EnemyStates
{
    [CreateAssetMenu(fileName = "IdleEnemyState", menuName = "_main/States/Enemy States/IdleState", order = 0)]
    public class IdleEnemyState : State
    {
        float timer = 2f;
        private Dictionary<EntityModel, EnemyModel> _entitiesData = new Dictionary<EntityModel, EnemyModel>();
        public override void EnterState(EntityModel model)
        {
            _entitiesData.Add(model, model as EnemyModel);
        }

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Enemy idle state execute");
            timer -= Time.deltaTime;
            if (timer >= _entitiesData[model].GetData().IdleTimer) model.IsIdle = false;
            //Debug.Log("Is allert? " + model.IsAllert);
            //Debug.Log("Is seeing target? " + enemymodel.LineOfSight(enemymodel.GetTarget().transform));
        }

        public override void ExitState(EntityModel model)
        {
            timer = 0f;
        }
    }
}