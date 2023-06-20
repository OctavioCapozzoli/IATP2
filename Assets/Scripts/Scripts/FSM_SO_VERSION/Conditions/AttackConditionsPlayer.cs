using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions
{
    [CreateAssetMenu(fileName = "AttackCondition", menuName = "_main/Conditions/Player Conditions/AttackCondition")]
    public class AttackConditionsPlayer : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.IsAttacking;
        }
    }
}
