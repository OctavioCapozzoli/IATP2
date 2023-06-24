using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "Walk State", menuName = "_main/States/Player States/Walk State", order = 0)]

    public class WalkStatePlayer : State
    {
        public override void ExecuteState(EntityModel model)
        {

            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(h, 0, v);
            if (h != 0 || v != 0)
            {
                model.Move(dir);
            }

        }
        public override void ExitState(EntityModel model)
        {
            PlayerModel playerModel = (PlayerModel)model;
            playerModel.View.PlayRunAnimation(false);
            playerModel.IsWalking = false;
        }

    }
}
