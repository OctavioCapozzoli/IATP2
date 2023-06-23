using _Main.Scripts.Entities;
using _Main.Scripts.Entities.Enemies;
using UnityEngine;

namespace _Main.Scripts.FSM_SO_VERSION.Conditions.EnemyConditions
{
    [CreateAssetMenu(fileName = "IsSeeingTarget", menuName = "_main/Conditions/Enemy Conditions/IsSeeingTarget")]
    public class IsSeeingTarget : StateCondition
    {
        public override bool CompleteCondition(EntityModel model)
        {

            var thisModel = (EnemyModel)model;

            return thisModel.LineOfSight(thisModel.GetTarget().transform);
        }
    }
}
