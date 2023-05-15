using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions
{
    [CreateAssetMenu(fileName = "WalkCondition", menuName = "_main/Conditions/WalkCondition")]
    public class WalkConditionsPlayer : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.isWalking;
        }
    }
}
