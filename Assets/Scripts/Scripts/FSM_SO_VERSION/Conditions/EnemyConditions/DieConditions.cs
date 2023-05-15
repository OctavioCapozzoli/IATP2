using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.EnemyConditions
{
    [CreateAssetMenu(fileName = "DieConditions", menuName = "_main/Conditions/DieConditions")]
    public class DieConditions : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.IsEntityDead();
        }
    }
}