using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.EnemyStates
{
    [CreateAssetMenu(fileName = "BlockState", menuName = "_main/States/EnemyStates/BlockState", order = 0)]
    public class BlockState : State
    {
        private Dictionary<EntityModel, EnemyModel> _entitiesData = new Dictionary<EntityModel, EnemyModel>();

        public override void EnterState(EntityModel model)
        {
            _entitiesData.Add(model, model as EnemyModel);
        }

        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Block state execute");
            //_entitiesData[model].EnemyView.PlayBlockAnimation();
        }
        public override void ExitState(EntityModel model)
        {
            _entitiesData[model].IsBlocking = false;
        }
    }
}
