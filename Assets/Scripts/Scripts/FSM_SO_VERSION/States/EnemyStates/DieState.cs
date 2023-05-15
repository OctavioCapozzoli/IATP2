using _Main.Scripts.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Scripts.FSM_SO_VERSION.States.EnemyStates
{
    [CreateAssetMenu(fileName = "DieState", menuName = "_main/States/EnemyStates/DieState", order = 0)]
    public class DieState : State
    {
        public override void EnterState(EntityModel model)
        {
            model.IsDead = true;
        }

        public override void ExecuteState(EntityModel model)
        {
            model.Die();
        }

        public override void ExitState(EntityModel model)
        {
            model.IsDead = false;
        }
    }
}