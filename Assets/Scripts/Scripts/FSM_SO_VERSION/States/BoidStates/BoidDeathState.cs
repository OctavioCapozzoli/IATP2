using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.BoidStates
{
    [CreateAssetMenu(fileName = "Boid Death State", menuName = "_main/States/Boid States/Death State", order = 0)]
    public class BoidDeathState : State
    {
        private Dictionary<EntityModel, EnemyMinion> _entitiesData = new Dictionary<EntityModel, EnemyMinion>();
        public override void EnterState(EntityModel model)
        {
            _entitiesData.Add(model, model as EnemyMinion);
            _entitiesData[model].Die();

        }

        public override void ExecuteState(EntityModel model)
        {

            Debug.Log("Boid state death execute");
        }

        public override void ExitState(EntityModel model)
        {

            _entitiesData.Remove(model);
        }
    }
}
