using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Player;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.States.PlayerStates
{
    [CreateAssetMenu(fileName = "WalkState", menuName = "_main/States/PlayerStates/WalkState", order = 0)]

    public class WalkStatePlayer : State
    {
        public override void ExecuteState(EntityModel model)
        {
            //var horizontalInput = model.transform.right * Input.GetAxis("Horizontal");
            //var verticalInput = model.transform.forward * Input.GetAxis("Vertical");
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(h, 0, v);
            //_entity.Move(dir);

            //Vector3 inputDir = (horizontalInput + verticalInput).normalized;
            //Vector3 wantedDir = new Vector3(inputDir.x, model.GetRigidbody().velocity.y, inputDir.z).normalized;

            if (h != 0 || v != 0)
            {
                model.Move(dir);
                //model.LookDir(model.GetFoward());
            }

        }
        public override void ExitState(EntityModel model)
        {
            PlayerModel playerModel = (PlayerModel)model;
            playerModel.View.PlayRunAnimation(false);
        }

    }
}
