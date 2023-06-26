using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.BossStates
{
    [CreateAssetMenu(fileName = "Seek State", menuName = "_main/States/Boss States/Seek State", order = 0)]
    public class SeekState : State
    {
        private Dictionary<EntityModel, BossEnemyModel> _entitiesData = new Dictionary<EntityModel, BossEnemyModel>();
        public override void EnterState(EntityModel model)
        {
            _entitiesData.Add(model, model as BossEnemyModel);
        }

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Enemy chase state execute");

            var dir = _entitiesData[model].Controller.SbSeek.GetDir();
            if (dir != Vector3.zero)
            {
                Debug.Log("Enemy puede moverse");
                _entitiesData[model].Move(dir);
            }
            else _entitiesData[model].IsChasing = false;
        }

        public override void ExitState(EntityModel model)
        {
            _entitiesData[model].IsChasing = false;
            _entitiesData.Remove(model);
        }
    }
}
