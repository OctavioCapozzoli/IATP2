using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.EnemyConditions
{
    
    [CreateAssetMenu(fileName = "IdleEnterCondition", menuName = "_main/Conditions/IdleEnterCondition")]
    public class IdleEnterCondition : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            if (model.IsAttacking) return false;
            return model.IsIdle;
        }
    }
}