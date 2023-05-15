using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.EnemyStates
{
    [CreateAssetMenu(fileName = "IdleEnemyState", menuName = "_main/States/EnemyStates/IdleState", order = 0)]
    public class IdleEnemyState : State
    {
        public override void EnterState(EntityModel model)
        {
            model.isIdle = true;
        }

        public override void ExecuteState(EntityModel model)
        {

        }

        public override void ExitState(EntityModel model)
        {
            model.isIdle = false;
        }
    }
}