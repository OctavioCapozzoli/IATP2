using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions
{
    [CreateAssetMenu(fileName = "SpecialAttackCondition", menuName = "_main/Conditions/SpecialAttackCondition")]
    public class SpecialAttackConditionsPlayer : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.IsSpecialAttacking;
        }
    }
}
