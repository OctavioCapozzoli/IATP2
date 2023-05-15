using _Main.Scripts.Entities;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.EnemyConditions
{
    [CreateAssetMenu(fileName = "IsAlert", menuName = "_main/Conditions/EnemyConditions/IsAlert")]
    public class IsAlert : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.isAllert;
        }
    }
}
