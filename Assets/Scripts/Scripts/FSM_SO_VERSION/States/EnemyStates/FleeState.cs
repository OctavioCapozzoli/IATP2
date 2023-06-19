using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.EnemyStates
{
    [CreateAssetMenu(fileName = "FleeState", menuName = "_main/States/EnemyStates/FleeState", order = 0)]
    public class FleeState : State
    {
        private Dictionary<EntityModel, EnemyModel> _entitiesData = new Dictionary<EntityModel, EnemyModel>();
        float healTimer = 1.5f;

        public override void EnterState(EntityModel model)
        {
            _entitiesData.Add(model, model as EnemyModel);
        }

        public override void ExecuteState(EntityModel model)
        {
            healTimer -= Time.deltaTime;
            if (healTimer > 0)
            {
                var modelData = _entitiesData[model].GetData();
                Vector3 fleePoint = new Vector3(Random.Range(modelData.SightRange, modelData.SightRange + 5), 0, Random.Range(modelData.SightRange, modelData.SightRange + 2)); //TODO setear variable de flee max distance
                var dir = fleePoint - _entitiesData[model].transform.position;
                _entitiesData[model].Move(dir);
                _entitiesData[model].Heal(2); //TODO setear healing value
            }
        }
    }
}
