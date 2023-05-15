using System.Collections.Generic;
using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Roulette_Wheel.EnemyRouletteWheel;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.EnemyStates
{
    [CreateAssetMenu(fileName = "ChaseState", menuName = "_main/States/EnemyStates/ChaseState", order = 0)]
    public class ChaseState : State
    {
        private Dictionary<EntityModel, EnemyModel> _entitiesData = new Dictionary<EntityModel, EnemyModel>();
        public override void EnterState(EntityModel model)
        {
            _entitiesData.Add(model, model as EnemyModel);
            
            
            //Activo la ruleta dentro del model
            _entitiesData[model].Controller.EnemyRoulette.RouletteAction();

            _entitiesData[model].exclamationSing.SetActive(true);
            _entitiesData[model].IsChasing = true;
        }
        
        public override void ExecuteState(EntityModel model)
        {
            
            var steering = _entitiesData[model].Controller.EnemySbController;
            _entitiesData[model].cooldownAttack -= Time.deltaTime;
            Vector3 dir = (steering.SbRouletteSteeringBh.GetDir()).normalized;
            
            if (dir != Vector3.zero)
            {
                _entitiesData[model].Move(dir);
            }
        }


        public override void ExitState(EntityModel model)
        {
            var lastDir = (_entitiesData[model].GetTarget().transform.position -
                           _entitiesData[model].transform.position).normalized;
            _entitiesData[model].SetLastViewDir(lastDir);
            _entitiesData[model].exclamationSing.SetActive(false);
            
            _entitiesData.Remove(model);
            
            
            model.IsChasing = false;
        }
    }
}
