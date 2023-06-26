using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.BossConditions
{
    [CreateAssetMenu(fileName = "Is In Attack Range?", menuName = "_main/Conditions/Boss Conditions/Is In Attack Range?")]
    public class IsInAttackRange : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {
            var thisModel = (BossEnemyModel)model;

            return Vector3.Distance(thisModel.transform.position, thisModel.GetTarget().transform.position) <= thisModel.GetData().AttackRange;
        }
    }
}
