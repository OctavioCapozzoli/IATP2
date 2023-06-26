using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "Walk State", menuName = "_main/States/Player States/Walk State", order = 0)]

    public class WalkStatePlayer : State
    {
        PlayerModel playerModel;
        public override void EnterState(EntityModel model)
        {
            playerModel = model as PlayerModel;
        }

        public override void ExecuteState(EntityModel model)
        {

            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(h, 0, v);
            if (h != 0 || v != 0)
            {
                playerModel.View.PlayRunAnimation(true);
                playerModel.Move(dir);
            }
            else playerModel.View.PlayRunAnimation(false);

        }
        public override void ExitState(EntityModel model)
        {
            playerModel.IsWalking = false;
        }

    }
}
