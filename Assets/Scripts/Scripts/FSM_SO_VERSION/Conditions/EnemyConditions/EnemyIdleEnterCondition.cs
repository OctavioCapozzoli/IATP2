using _Main.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.EnemyConditions
{

    [CreateAssetMenu(fileName = "EnemyIdleEnterCondition", menuName = "_main/Conditions/Enemy Conditions/EnemyIdleEnterCondition")]
    public class EnemyIdleEnterCondition : StateCondition
    {

        public override bool CompleteCondition(EntityModel model)
        {
            return model.IsIdle;
        }

    }
}
