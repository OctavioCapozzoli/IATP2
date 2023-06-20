using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel;
using System.Collections.Generic;
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
            _entitiesData[model].Controller.EnemyRoulette.EnemySbRouletteAction();

            _entitiesData[model].exclamationSing.SetActive(true);
            _entitiesData[model].IsChasing = true;
        }

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Enemy chase state execute");

            var steering = _entitiesData[model].Controller.EnemySbController;
            _entitiesData[model].cooldownAttack -= Time.deltaTime;
            Vector3 dir = steering.SbRouletteSteeringBh.GetDir().normalized;

            if (dir != Vector3.zero)
            {
                //TODO Ver si no se marea con las animaciones ( El move tiene el walk anim con el float)
                _entitiesData[model].EnemyView.PlayRunAnimation(true);
                _entitiesData[model].Move(dir);
            }
        }


        public override void ExitState(EntityModel model)
        {
            var lastDir = (_entitiesData[model].GetTarget().transform.position -
                           _entitiesData[model].transform.position).normalized;
            _entitiesData[model].SetLastViewDir(lastDir);
            _entitiesData[model].exclamationSing.SetActive(false);
            _entitiesData[model].EnemyView.PlayRunAnimation(false);
            _entitiesData[model].IsWalking = false;
            _entitiesData[model].IsChasing = false;
            _entitiesData.Remove(model);
        }
    }
}
