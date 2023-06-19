using _Main.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.EnemyConditions
{
    [CreateAssetMenu(fileName = "IsBlockingAttack", menuName = "_main/Conditions/EnemyConditions/IsBlockingAttack")]
    public class IsBlockingAttack : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.IsBlocking;
        }
    }
}
