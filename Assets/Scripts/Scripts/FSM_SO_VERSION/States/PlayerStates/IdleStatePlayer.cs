using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "_main/States/PlayerStates/IdleState", order = 0)]
    public class IdleStatePlayer : State
    {
        public override void EnterState(EntityModel model)
        {
            model.GetRigidbody().velocity = Vector3.zero;
        }
        public override void ExecuteState(EntityModel model)
        {
            model.GetRigidbody().velocity = Vector3.zero;
        }
    }
}
