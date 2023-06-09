using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.BoidStates
{
    [CreateAssetMenu(fileName = "Boid Seek State", menuName = "_main/States/Boid States/Seek State", order = 0)]
    public class BoidSeekState : State
    {
        private Dictionary<EntityModel, EnemyMinion> _entitiesData = new Dictionary<EntityModel, EnemyMinion>();
        public override void EnterState(EntityModel model)
        {
            _entitiesData.Add(model, model as EnemyMinion);
            
        }

        public override void ExecuteState(EntityModel model)
        {
            //Debug.Log("Boid state seek execute");
            if(_entitiesData[model].GetComponent<Leader>().target != null)
            {
                _entitiesData[model].LookDir(_entitiesData[model].GetComponent<FlockingManager>().RunFlockingDir());
                _entitiesData[model].Move(_entitiesData[model].GetComponent<FlockingManager>().RunFlockingDir());
                if (_entitiesData[model].isCollidingWithPlayer)
                {
                    _entitiesData[model].attackedPlayer = true;
                }
            }
        }


        public override void ExitState(EntityModel model)
        {

            _entitiesData.Remove(model);
        }
    }
}
