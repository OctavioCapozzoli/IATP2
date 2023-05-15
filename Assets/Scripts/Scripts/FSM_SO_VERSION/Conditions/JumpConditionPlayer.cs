using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions
{
    [CreateAssetMenu(fileName = "JumpCondition", menuName = "_main/Conditions/JumpCondition")]
    public class JumpConditionPlayer : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.IsJumping;
        }
    }
}
