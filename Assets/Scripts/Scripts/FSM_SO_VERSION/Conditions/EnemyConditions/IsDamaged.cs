using _Main.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.EnemyConditions
{
    [CreateAssetMenu(fileName = "IsDamaged", menuName = "_main/Conditions/EnemyConditions/IsDamaged")]
    public class IsDamaged : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            return model.IsDamaged;
        }
    }
}
