using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.EnemyConditions
{
    [CreateAssetMenu(fileName = "IsFleeingFromPlayer", menuName = "_main/Conditions/Enemy Conditions/IsFleeingFromPlayer")]
    public class IsFleeingFromPlayer : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            var thisModel = (EnemyModel)model;
            return thisModel.CheckFleeFromPlayer();
        }
    }
}
