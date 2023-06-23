using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "_main/States/PlayerStates/IdleState", order = 0)]
    public class IdleStatePlayer : State
    {
        public override void EnterState(EntityModel model)
        {
            PlayerModel playerModel = model as PlayerModel;
            playerModel.View.PlayRunAnimation(false);
        }
        public override void ExecuteState(EntityModel model)
        {
            Debug.Log("Idle state player execute");
        }
    }
}
